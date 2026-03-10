# Bài thực hành số 3 - ASP.NET MVC

## Cấu trúc thư mục

- Controllers: chứa các controller xử lý request
- Models: chứa các class dữ liệu
- Views: chứa giao diện hiển thị
- wwwroot: chứa file tĩnh (css, js, image)
- Program.cs: file khởi động project

## Routing trong ASP.NET MVC

Routing dùng để ánh xạ URL tới Controller và Action.

Ví dụ:

{controller=Home}/{action=Index}/{id?}

## Namespace trong C#

Namespace dùng để nhóm các class lại với nhau và tránh trùng tên.

## Controller và View

Controller xử lý logic và trả về View.

View là giao diện hiển thị cho người dùng.

Ví dụ trong bài:
DemoController trả về View Index hiển thị:

Hello Lam - SV001
