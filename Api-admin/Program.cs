using BLL.Interfaces;
using BLL;
using DAL.Repository.Interfaces;
using DAL.Repository;
using DAL;
using DataAccessLayer;
using DataAccessLayer.Repository.Interfaces;
using DataAccessLayer.Repository;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
//thuong hieu
builder.Services.AddTransient<IthuongHieuRepository, ThuongHieuRepository>();
builder.Services.AddTransient<IThuongHieuBusiness, ThuongHieuBusiness>();
//danh muc
builder.Services.AddTransient<IDanhMucRepository, DanhMucRepository>();
builder.Services.AddTransient<IDanhMucBusiness, DanhMucBusiness>();
//tai khoan Quan ly 
builder.Services.AddTransient<ITaiKhoanQuanLyRepository, TaiKhoanQuanLyRepository>();
builder.Services.AddTransient<ITaiKhoanQuanLyBusiness, TaiKhoanQuanLyBusiness>();
// SanPham
builder.Services.AddTransient<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddTransient<ISanPhamBusiness, SanPhamBusiness>();
//DonHang
builder.Services.AddTransient<IDonHangRepository, DonHangRepository>();
builder.Services.AddTransient<IDonHangBusiness, DonHangBusiness>();



builder.Services.AddCors(options =>
{

    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("*") // Điều chỉnh tên miền hoặc địa chỉ IP của ứng dụng web của bạn.
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();
app.Run();
    