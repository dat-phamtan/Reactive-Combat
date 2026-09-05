# TÀI LIỆU KIẾN TRÚC KỸ THUẬT - REACTIVE COMBAT

**Dự án:** Game 2D Turn-Based RPG "Reactive Combat"
**Nền tảng:** Unity 2D URP, C#

---

## 1. TỔNG QUAN HỆ THỐNG
Reactive Combat là sự kết hợp giữa tư duy chiến thuật đánh theo lượt (Turn-based) và kỹ năng phản xạ thời gian thực (Real-time timing). Để đảm bảo hệ thống có thể mở rộng, dễ bảo trì và không bị lỗi phụ thuộc chéo (spaghetti code), toàn bộ kiến trúc mã nguồn được thiết kế dựa trên các tiêu chuẩn công nghiệp khắt khe.

---

## 2. CÁC TIÊU CHUẨN KIẾN TRÚC PHẢI ĐẢM BẢO

### 2.1. Tuân thủ Nguyên lý SOLID
Toàn bộ mã nguồn phải được thiết kế xoay quanh 5 nguyên lý SOLID:
*   **S (Single Responsibility Principle - Trách nhiệm đơn lẻ):** Mỗi class chỉ đảm nhận một nhiệm vụ. Ví dụ: `DamageCalculator` chỉ tính sát thương, không can thiệp vào thanh máu; `TurnManager` chỉ sắp xếp lượt đi, không quản lý UI.
*   **O (Open/Closed Principle - Đóng/Mở):** Hệ thống được thiết kế để mở rộng bằng cách thêm code mới thay vì sửa code cũ. Việc thêm một kỹ năng mới chỉ cần tạo một class mới implement `ICombatCommand` mà không cần chạm vào lõi `CombatManager`.
*   **L (Liskov Substitution Principle - Thay thế Liskov):** Bất kỳ nhân vật nào (Player, Boss, Minion) khi implement `ICharacterEntity` đều có thể được xử lý mượt mà trong hệ thống hàng đợi và sát thương mà không cần ép kiểu (type casting) thủ công.
*   **I (Interface Segregation Principle - Phân tách Interface):** Chia nhỏ interface thay vì dùng chung một interface khổng lồ. Ví dụ: Tách `IDamageable` (quản lý máu, nhận sát thương) và `ICharacterStats` (quản lý chỉ số tốc độ, sức mạnh) riêng biệt.
*   **D (Dependency Inversion Principle - Đảo ngược phụ thuộc):** Các module cấp cao (Combat System) không phụ thuộc vào các module cấp thấp (Nhân vật cụ thể), mà cả hai cùng phụ thuộc vào Abstraction (Interface). 

### 2.2. Dependency Injection (DI)
Tuyệt đối **KHÔNG SỬ DỤNG SINGLETON** cho các hệ thống quản lý cốt lõi. 
*   **Công cụ:** Sử dụng các framework DI như **Zenject** hoặc **VContainer**.
*   **Luồng hoạt động:** Các service như `ITurnManager`, `IDamageCalculator`, `ITimingSystem` sẽ được đăng ký (Bind) ở cấp độ Scene hoặc Global. Khi một class cần sử dụng, DI framework sẽ tự động tiêm (inject) các instance này thông qua Constructor. Điều này giúp dễ dàng viết Unit Test (Mocking).

### 2.3. Event-Driven Architecture (Kiến trúc hướng sự kiện)
Giải quyết triệt để vấn đề coupling giữa các module.
*   Các class giao tiếp với nhau bằng cách phát (Invoke) và lắng nghe (Subscribe) các sự kiện (`Action`, `Func`, `UnityEvent`).
*   Ví dụ: Khi nhân vật nhận sát thương, class nhân vật chỉ phát ra sự kiện `OnHealthChanged`. Khối mã hiển thị thanh máu tự động bắt sự kiện này và cập nhật UI.

### 2.4. Tách bạch UI - Logic - Data (MVC / MVP)
*   **Data (Model):** Chỉ chứa dữ liệu thuần túy (Máu, Năng lượng, Tốc độ, Hệ số nhân sát thương). Không chứa bất kỳ hàm nào liên quan đến Unity `MonoBehaviour` nếu không cần thiết.
*   **Logic (Controller/System):** Chứa các hệ thống tính toán (Turn Manager, Damage Calculator). Không chứa reference đến bất kỳ UI text hay image nào.
*   **UI (View):** Các script gắn trên Canvas. Nhiệm vụ duy nhất là lắng nghe sự kiện từ Model/Logic để cập nhật hình ảnh, và nhận input từ người chơi để truyền xuống Logic.

---

## 3. CÁC MẪU THIẾT KẾ (DESIGN PATTERNS) CHỦ ĐẠO

1.  **Command Pattern:** Được sử dụng cho toàn bộ thao tác trong trận đấu (Đánh thường, Dùng item, Kỹ năng). Cho phép lưu lịch sử hành động, dễ dàng quản lý hàng đợi và thực thi tuần tự.
2.  **State Pattern (Finite State Machine - FSM):** Được sử dụng thiết kế AI cho Boss. Boss sẽ có các trạng thái như `Pha1_Basic`, `Pha2_Combo`, `Pha3_Enrage`. Mỗi State tự quản lý logic ra đòn và tự động chuyển pha dựa trên % máu.
3.  **Observer Pattern:** Nền tảng của hệ thống Event-Driven, dùng để trigger các hoạt ảnh, hiệu ứng vỡ hạt (particles) và rung màn hình (screen shake) khi bắt trúng Perfect/Early/Late.

---

## 4. CHIẾN LƯỢC LƯU TRỮ DỮ LIỆU (DATA PERSISTENCE)
Thay thế hoàn toàn việc lưu JSON truyền thống để tối ưu hiệu suất, bảo mật và khả năng mở rộng.

1.  **ScriptableObjects (Dữ liệu tĩnh - Read-only):**
    *   Lưu trữ các template của nhân vật, chỉ số cơ bản, định nghĩa kỹ năng và trang bị. 
    *   Ưu điểm: Tích hợp sâu vào Unity Editor, không tốn tài nguyên parse dữ liệu, dễ dàng tinh chỉnh thiết kế (Game Design).
2.  **SQLite (Dữ liệu cấu trúc phức tạp):**
    *   Sử dụng cho hệ thống Cây kỹ năng (Skill Tree) và Kho đồ (Inventory).
    *   Ưu điểm: Truy vấn (Query) cực nhanh bằng SQL, dễ dàng quản lý quan hệ (ví dụ: Vũ khí A đang được trang bị bởi Nhân vật B).
3.  **Binary Serialization / MessagePack (Dữ liệu Runtime / Save File):**
    *   Dùng để lưu tiến trình (Save Game), mức máu hiện tại, vị trí người chơi.
    *   Ưu điểm: Dung lượng file cực nhẹ, tốc độ Serialize/Deserialize nhanh hơn JSON gấp nhiều lần, dữ liệu ở dạng nhị phân giúp hạn chế người chơi gian lận chỉnh sửa file save cục bộ.
