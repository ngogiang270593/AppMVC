## Controller
- Là một lớp kề thừa lớp Controller : Microsoft.AspNetCore.Mvc.Controller
- Action trong controller là một phương thức public (không được static)
- Action trả về bất kỳ kiểu dữ liệu nào , thường là IActionResult 
- Các dịch vụ inject vào controller qua hàm tạo
## View
- Là file .cshtml
- View cho Action lưu tại : /View/ControllerName/ActionName.cshtml
## Truyền dữ liệu sang View
- Model
- ViewData
- ViewBag
- TempData