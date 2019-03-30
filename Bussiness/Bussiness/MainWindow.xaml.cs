using Bussiness.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bussiness
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<MuiGio> danhSachMuiGio = new List<MuiGio>() {
            new MuiGio() { ValueMuiGio = "(GMT+07:00) Asia/Ho Chi_Minh", NameMuiGio="(GMT+07:00) Asia/Ho Chi_Minh" },
            new MuiGio() { ValueMuiGio = "(GMT-10:00) Pacific/Honolulu", NameMuiGio="(GMT-10:00) Pacific/Honolulu" },
            new MuiGio() { ValueMuiGio = "(GMT-08:00) America/Anchorage", NameMuiGio="(GMT-08:00) America/Anchorage" },
            new MuiGio() { ValueMuiGio = "(GMT-07:00) America/Dawson", NameMuiGio="(GMT-07:00) America/Dawson" },
            new MuiGio() { ValueMuiGio = "(GMT-07:00) America/Dawson Creek", NameMuiGio="(GMT-07:00) America/Dawson Creek" },
            new MuiGio() { ValueMuiGio = "(GMT-07:00) America/Hermosillo", NameMuiGio="(GMT-07:00) America/Hermosillo" },
            new MuiGio() { ValueMuiGio = "(GMT-07:00) America/Los Angeles", NameMuiGio="(GMT-07:00) America/Los Angeles" },
            new MuiGio() { ValueMuiGio = "(GMT-07:00) America/Mazatlan", NameMuiGio="(GMT-07:00) America/Mazatlan" },
            new MuiGio() { ValueMuiGio = "(GMT-07:00) America/Phoenix", NameMuiGio="(GMT-07:00) America/Phoenix" },
            new MuiGio() { ValueMuiGio = "(GMT-07:00) America/Tijuana", NameMuiGio="(GMT-07:00) America/Tijuana" },
            new MuiGio() { ValueMuiGio = "(GMT-07:00) America/Vancouver", NameMuiGio="(GMT-07:00) America/Vancouver" },
            new MuiGio() { ValueMuiGio = "(GMT-06:00) America/Costa Rica", NameMuiGio="(GMT-06:00) America/Costa Rica" },
            new MuiGio() { ValueMuiGio = "(GMT-06:00) America/Denver", NameMuiGio="(GMT-06:00) America/Denver" },
            new MuiGio() { ValueMuiGio = "(GMT-06:00) America/Edmonton", NameMuiGio="(GMT-06:00) America/Edmonton" },
            new MuiGio() { ValueMuiGio = "(GMT-06:00) America/El Salvador", NameMuiGio="(GMT-06:00) America/El Salvador" },
            new MuiGio() { ValueMuiGio = "(GMT-06:00) America/Guatemala", NameMuiGio="(GMT-06:00) America/Guatemala" },
            new MuiGio() { ValueMuiGio = "(GMT-06:00) America/Managua", NameMuiGio="(GMT-06:00) America/Managua" },
            new MuiGio() { ValueMuiGio = "(GMT-06:00) America/Mexico City", NameMuiGio="(GMT-06:00) America/Mexico City" },
            new MuiGio() { ValueMuiGio = "(GMT-06:00) America/Regina", NameMuiGio="(GMT-06:00) America/Regina" },
            new MuiGio() { ValueMuiGio = "(GMT-06:00) America/Tegucigalpa", NameMuiGio="(GMT-06:00) America/Tegucigalpa" },
            new MuiGio() { ValueMuiGio = "(GMT-06:00) Pacific/Galapagos", NameMuiGio="(GMT-06:00) Pacific/Galapagos" },
            new MuiGio() { ValueMuiGio = "(GMT-05:00) America/Atikokan", NameMuiGio="(GMT-05:00) America/Atikokan" },
            new MuiGio() { ValueMuiGio = "(GMT-05:00) America/Bogota", NameMuiGio="(GMT-05:00) America/Bogota" },
            new MuiGio() { ValueMuiGio = "(GMT-05:00) America/Chicago", NameMuiGio="(GMT-05:00) America/Chicago" },
            new MuiGio() { ValueMuiGio = "(GMT-05:00) America/Guayaquil", NameMuiGio="(GMT-05:00) America/Guayaquil" },
            new MuiGio() { ValueMuiGio = "(GMT-05:00) America/Jamaica", NameMuiGio="(GMT-05:00) America/Jamaica" },
            new MuiGio() { ValueMuiGio = "(GMT-05:00) America/Lima", NameMuiGio="(GMT-05:00) America/Lima" },
            new MuiGio() { ValueMuiGio = "(GMT-05:00) America/Panama", NameMuiGio="(GMT-05:00) America/Panama" },
            new MuiGio() { ValueMuiGio = "(GMT-05:00) America/Rainy River", NameMuiGio="(GMT-05:00) America/Rainy River" },
            new MuiGio() { ValueMuiGio = "(GMT-05:00) America/Winnipeg", NameMuiGio="(GMT-05:00) America/Winnipeg" },
            new MuiGio() { ValueMuiGio = "(GMT-05:00) Pacific/Easter", NameMuiGio="(GMT-05:00) Pacific/Easter" },
            new MuiGio() { ValueMuiGio = "(GMT-04:00) America/Asuncion", NameMuiGio="(GMT-04:00) America/Asuncion" },
            new MuiGio() { ValueMuiGio = "(GMT-04:00) America/Blanc-Sablon", NameMuiGio="(GMT-04:00) America/Blanc-Sablon" },
            new MuiGio() { ValueMuiGio = "(GMT-04:00) America/Campo Grande", NameMuiGio="(GMT-04:00) America/Campo Grande" },
            new MuiGio() { ValueMuiGio = "(GMT-04:00) America/Caracas", NameMuiGio="(GMT-04:00) America/Caracas" },
            new MuiGio() { ValueMuiGio = "(GMT-04:00) America/Detroit", NameMuiGio="(GMT-04:00) America/Detroit" },
            new MuiGio() { ValueMuiGio = "(GMT-04:00) America/Iqaluit", NameMuiGio="(GMT-04:00) America/Iqaluit" },
            new MuiGio() { ValueMuiGio = "(GMT-04:00) America/La Paz", NameMuiGio="(GMT-04:00) America/La Paz" },
            new MuiGio() { ValueMuiGio = "(GMT-04:00) America/Nassau", NameMuiGio="(GMT-04:00) America/Nassau" },
            new MuiGio() { ValueMuiGio = "(GMT-04:00) America/New York", NameMuiGio="(GMT-04:00) America/New York" },
            new MuiGio() { ValueMuiGio = "(GMT-04:00) America/Port of_Spain", NameMuiGio="(GMT-04:00) America/Port of_Spain" },
            new MuiGio() { ValueMuiGio = "(GMT-04:00) America/Puerto Rico", NameMuiGio="(GMT-04:00) America/Puerto Rico" },
            new MuiGio() { ValueMuiGio = "(GMT-04:00) America/Santo Domingo", NameMuiGio="(GMT-04:00) America/Santo Domingo" },
            new MuiGio() { ValueMuiGio = "(GMT-04:00) America/Toronto", NameMuiGio="(GMT-04:00) America/Toronto" },
            new MuiGio() { ValueMuiGio = "(GMT-03:00) America/Argentina/Buenos Aires", NameMuiGio="(GMT-03:00) America/Argentina/Buenos Aires" },
            new MuiGio() { ValueMuiGio = "(GMT-03:00) America/Argentina/Salta", NameMuiGio="(GMT-03:00) America/Argentina/Salta" },
            new MuiGio() { ValueMuiGio = "(GMT-03:00) America/Argentina/San Luis", NameMuiGio="(GMT-03:00) America/Argentina/San Luis" },
            new MuiGio() { ValueMuiGio = "(GMT-03:00) America/Belem", NameMuiGio="(GMT-03:00) America/Belem" },
            new MuiGio() { ValueMuiGio = "(GMT-03:00) America/Halifax", NameMuiGio="(GMT-03:00) America/Halifax" },
            new MuiGio() { ValueMuiGio = "(GMT-03:00) America/Montevideo", NameMuiGio="(GMT-03:00) America/Montevideo" },
            new MuiGio() { ValueMuiGio = "(GMT-03:00) America/Santiago", NameMuiGio="(GMT-03:00) America/Santiago" },
            new MuiGio() { ValueMuiGio = "(GMT-03:00) America/Sao Paulo", NameMuiGio="(GMT-03:00) America/Sao Paulo" },
            new MuiGio() { ValueMuiGio = "(GMT-02:30) America/St Johns", NameMuiGio="(GMT-02:30) America/St Johns" },
            new MuiGio() { ValueMuiGio = "(GMT-02:00) America/Noronha", NameMuiGio="(GMT-02:00) America/Noronha" },
            new MuiGio() { ValueMuiGio = "(GMT-01:00) Atlantic/Azores", NameMuiGio="(GMT-01:00) Atlantic/Azores" },
            new MuiGio() { ValueMuiGio = "(GMT+00:00) Africa/Accra", NameMuiGio="(GMT+00:00) Africa/Accra" },
            new MuiGio() { ValueMuiGio = "(GMT+00:00) Atlantic/Canary", NameMuiGio="(GMT+00:00) Atlantic/Canary" },
            new MuiGio() { ValueMuiGio = "(GMT+00:00) Atlantic/Reykjavik", NameMuiGio="(GMT+00:00) Atlantic/Reykjavik" },
            new MuiGio() { ValueMuiGio = "(GMT+00:00) Europe/Dublin", NameMuiGio="(GMT+00:00) Europe/Dublin" },
            new MuiGio() { ValueMuiGio = "(GMT+00:00) Europe/Lisbon", NameMuiGio="(GMT+00:00) Europe/Lisbon" },
            new MuiGio() { ValueMuiGio = "(GMT+00:00) Europe/London", NameMuiGio="(GMT+00:00) Europe/London" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Africa/Casablanca", NameMuiGio="(GMT+01:00) Africa/Casablanca" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Africa/Lagos", NameMuiGio="(GMT+01:00) Africa/Lagos" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Africa/Tunis", NameMuiGio="(GMT+01:00) Africa/Tunis" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Amsterdam", NameMuiGio="(GMT+01:00) Europe/Amsterdam" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Belgrade", NameMuiGio="(GMT+01:00) Europe/Belgrade" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Berlin", NameMuiGio="(GMT+01:00) Europe/Berlin" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Bratislava", NameMuiGio="(GMT+01:00) Europe/Bratislava" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Brussels", NameMuiGio="(GMT+01:00) Europe/Brussels" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Budapest", NameMuiGio="(GMT+01:00) Europe/Budapest" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Copenhagen", NameMuiGio="(GMT+01:00) Europe/Copenhagen" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Ljubljana", NameMuiGio="(GMT+01:00) Europe/Ljubljana" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Luxembourg", NameMuiGio="(GMT+01:00) Europe/Luxembourg" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Madrid", NameMuiGio="(GMT+01:00) Europe/Madrid" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Malta", NameMuiGio="(GMT+01:00) Europe/Malta" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Oslo", NameMuiGio="(GMT+01:00) Europe/Oslo" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Paris", NameMuiGio="(GMT+01:00) Europe/Paris" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Prague", NameMuiGio="(GMT+01:00) Europe/Prague" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Rome", NameMuiGio="(GMT+01:00) Europe/Rome" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Sarajevo", NameMuiGio="(GMT+01:00) Europe/Sarajevo" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Skopje", NameMuiGio="(GMT+01:00) Europe/Skopje" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Stockholm", NameMuiGio="(GMT+01:00) Europe/Stockholm" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Vienna", NameMuiGio="(GMT+01:00) Europe/Vienna" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Warsaw", NameMuiGio="(GMT+01:00) Europe/Warsaw" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Zagreb", NameMuiGio="(GMT+01:00) Europe/Zagreb" },
            new MuiGio() { ValueMuiGio = "(GMT+01:00) Europe/Zurich", NameMuiGio="(GMT+01:00) Europe/Zurich" },
            new MuiGio() { ValueMuiGio = "(GMT+02:00) Africa/Cairo", NameMuiGio="(GMT+02:00) Africa/Cairo" },
            new MuiGio() { ValueMuiGio = "(GMT+02:00) Africa/Johannesburg", NameMuiGio="(GMT+02:00) Africa/Johannesburg" },
            new MuiGio() { ValueMuiGio = "(GMT+02:00) Asia/Beirut", NameMuiGio="(GMT+02:00) Asia/Beirut" },
            new MuiGio() { ValueMuiGio = "(GMT+02:00) Asia/Nicosia", NameMuiGio="(GMT+02:00) Asia/Nicosia" },
            new MuiGio() { ValueMuiGio = "(GMT+02:00) Europe/Athens", NameMuiGio="(GMT+02:00) Europe/Athens" },
            new MuiGio() { ValueMuiGio = "(GMT+02:00) Europe/Bucharest", NameMuiGio="(GMT+02:00) Europe/Bucharest" },
            new MuiGio() { ValueMuiGio = "(GMT+02:00) Europe/Helsinki", NameMuiGio="(GMT+02:00) Europe/Helsinki" },
            new MuiGio() { ValueMuiGio = "(GMT+02:00) Europe/Kaliningrad", NameMuiGio="(GMT+02:00) Europe/Kaliningrad" },
            new MuiGio() { ValueMuiGio = "(GMT+02:00) Europe/Kiev", NameMuiGio="(GMT+02:00) Europe/Kiev" },
            new MuiGio() { ValueMuiGio = "(GMT+02:00) Europe/Riga", NameMuiGio="(GMT+02:00) Europe/Riga" },
            new MuiGio() { ValueMuiGio = "(GMT+02:00) Europe/Sofia", NameMuiGio="(GMT+02:00) Europe/Sofia" },
            new MuiGio() { ValueMuiGio = "(GMT+02:00) Europe/Tallinn", NameMuiGio="(GMT+02:00) Europe/Tallinn" },
            new MuiGio() { ValueMuiGio = "(GMT+02:00) Europe/Vilnius", NameMuiGio="(GMT+02:00) Europe/Vilnius" },
            new MuiGio() { ValueMuiGio = "(GMT+03:00) Africa/Nairobi", NameMuiGio="(GMT+03:00) Africa/Nairobi" },
            new MuiGio() { ValueMuiGio = "(GMT+03:00) Asia/Amman", NameMuiGio="(GMT+03:00) Asia/Amman" },
            new MuiGio() { ValueMuiGio = "(GMT+03:00) Asia/Baghdad", NameMuiGio="(GMT+03:00) Asia/Baghdad" },
            new MuiGio() { ValueMuiGio = "(GMT+03:00) Asia/Bahrain", NameMuiGio="(GMT+03:00) Asia/Bahrain" },
            new MuiGio() { ValueMuiGio = "(GMT+03:00) Asia/Gaza", NameMuiGio="(GMT+03:00) Asia/Gaza" },
            new MuiGio() { ValueMuiGio = "(GMT+03:00) Asia/Jerusalem", NameMuiGio="(GMT+03:00) Asia/Jerusalem" },
            new MuiGio() { ValueMuiGio = "(GMT+03:00) Asia/Kuwait", NameMuiGio="(GMT+03:00) Asia/Kuwait" },
            new MuiGio() { ValueMuiGio = "(GMT+03:00) Asia/Qatar", NameMuiGio="(GMT+03:00) Asia/Qatar" },
            new MuiGio() { ValueMuiGio = "(GMT+03:00) Asia/Riyadh", NameMuiGio="(GMT+03:00) Asia/Riyadh" },
            new MuiGio() { ValueMuiGio = "(GMT+03:00) Europe/Istanbul", NameMuiGio="(GMT+03:00) Europe/Istanbul" },
            new MuiGio() { ValueMuiGio = "(GMT+03:00) Europe/Moscow", NameMuiGio="(GMT+03:00) Europe/Moscow" },
            new MuiGio() { ValueMuiGio = "(GMT+04:00) Asia/Dubai", NameMuiGio="(GMT+04:00) Asia/Dubai" },
            new MuiGio() { ValueMuiGio = "(GMT+04:00) Asia/Muscat", NameMuiGio="(GMT+04:00) Asia/Muscat" },
            new MuiGio() { ValueMuiGio = "(GMT+04:00) Europe/Samara", NameMuiGio="(GMT+04:00) Europe/Samara" },
            new MuiGio() { ValueMuiGio = "(GMT+04:00) Indian/Mauritius", NameMuiGio="(GMT+04:00) Indian/Mauritius" },
            new MuiGio() { ValueMuiGio = "(GMT+05:00) Asia/Karachi", NameMuiGio="(GMT+05:00) Asia/Karachi" },
            new MuiGio() { ValueMuiGio = "(GMT+05:00) Asia/Yekaterinburg", NameMuiGio="(GMT+05:00) Asia/Yekaterinburg" },
            new MuiGio() { ValueMuiGio = "(GMT+05:00) Indian/Maldives", NameMuiGio="(GMT+05:00) Indian/Maldives" },
            new MuiGio() { ValueMuiGio = "(GMT+05:30) Asia/Colombo", NameMuiGio="(GMT+05:30) Asia/Colombo" },
            new MuiGio() { ValueMuiGio = "(GMT+05:30) Asia/Kolkata", NameMuiGio="(GMT+05:30) Asia/Kolkata" },
            new MuiGio() { ValueMuiGio = "(GMT+05:45) Asia/Kathmandu", NameMuiGio="(GMT+05:45) Asia/Kathmandu" },
            new MuiGio() { ValueMuiGio = "(GMT+06:00) Asia/Dhaka", NameMuiGio="(GMT+06:00) Asia/Dhaka" },
            new MuiGio() { ValueMuiGio = "(GMT+06:00) Asia/Omsk", NameMuiGio="(GMT+06:00) Asia/Omsk" },
            new MuiGio() { ValueMuiGio = "(GMT+07:00) Asia/Bangkok", NameMuiGio="(GMT+07:00) Asia/Bangkok" },
            new MuiGio() { ValueMuiGio = "(GMT+07:00) Asia/Jakarta", NameMuiGio="(GMT+07:00) Asia/Jakarta" },
            new MuiGio() { ValueMuiGio = "(GMT+07:00) Asia/Krasnoyarsk", NameMuiGio="(GMT+07:00) Asia/Krasnoyarsk" },
            new MuiGio() { ValueMuiGio = "(GMT+08:00) Asia/Hong Kong", NameMuiGio="(GMT+08:00) Asia/Hong Kong" },
            new MuiGio() { ValueMuiGio = "(GMT+08:00) Asia/Irkutsk", NameMuiGio="(GMT+08:00) Asia/Irkutsk" },
            new MuiGio() { ValueMuiGio = "(GMT+08:00) Asia/Kuala Lumpur", NameMuiGio="(GMT+08:00) Asia/Kuala Lumpur" },
            new MuiGio() { ValueMuiGio = "(GMT+08:00) Asia/Makassar", NameMuiGio="(GMT+08:00) Asia/Makassar" },
            new MuiGio() { ValueMuiGio = "(GMT+08:00) Asia/Manila", NameMuiGio="(GMT+08:00) Asia/Manila" },
            new MuiGio() { ValueMuiGio = "(GMT+08:00) Asia/Shanghai", NameMuiGio="(GMT+08:00) Asia/Shanghai" },
            new MuiGio() { ValueMuiGio = "(GMT+08:00) Asia/Singapore", NameMuiGio="(GMT+08:00) Asia/Singapore" },
            new MuiGio() { ValueMuiGio = "(GMT+08:00) Asia/Taipei", NameMuiGio="(GMT+08:00) Asia/Taipei" },
            new MuiGio() { ValueMuiGio = "(GMT+08:00) Australia/Perth", NameMuiGio="(GMT+08:00) Australia/Perth" },
            new MuiGio() { ValueMuiGio = "(GMT+09:00) Asia/Jayapura", NameMuiGio="(GMT+09:00) Asia/Jayapura" },
            new MuiGio() { ValueMuiGio = "(GMT+09:00) Asia/Seoul", NameMuiGio="(GMT+09:00) Asia/Seoul" },
            new MuiGio() { ValueMuiGio = "(GMT+09:00) Asia/Tokyo", NameMuiGio="(GMT+09:00) Asia/Tokyo" },
            new MuiGio() { ValueMuiGio = "(GMT+09:00) Asia/Yakutsk", NameMuiGio="(GMT+09:00) Asia/Yakutsk" },
            new MuiGio() { ValueMuiGio = "(GMT+10:00) Asia/Vladivostok", NameMuiGio="(GMT+10:00) Asia/Vladivostok" },
            new MuiGio() { ValueMuiGio = "(GMT+10:30) Australia/Broken Hill", NameMuiGio="(GMT+10:30) Australia/Broken Hill" },
            new MuiGio() { ValueMuiGio = "(GMT+11:00) Asia/Magadan", NameMuiGio="(GMT+11:00) Asia/Magadan" },
            new MuiGio() { ValueMuiGio = "(GMT+11:00) Australia/Melbourne", NameMuiGio="(GMT+11:00) Australia/Melbourne" },
            new MuiGio() { ValueMuiGio = "(GMT+11:00) Australia/Sydney", NameMuiGio="(GMT+11:00) Australia/Sydney" },
            new MuiGio() { ValueMuiGio = "(GMT+12:00) Asia/Kamchatka", NameMuiGio="(GMT+12:00) Asia/Kamchatka" },
            new MuiGio() { ValueMuiGio = "(GMT+13:00) Pacific/Auckland", NameMuiGio="(GMT+13:00) Pacific/Auckland" },
        };
        public List<LoaiTien> danhSachLoaiTien = new List<LoaiTien>() {
            new LoaiTien() { ValueLoaiTien = "USD", NameLoaiTien="USD — Đô la Mỹ" },
            new LoaiTien() { ValueLoaiTien = "AED", NameLoaiTien="AED — Đồng Dirham UAE" },
            new LoaiTien() { ValueLoaiTien = "ARS", NameLoaiTien="ARS — Đồng Peso Argentina" },
            new LoaiTien() { ValueLoaiTien = "AUD", NameLoaiTien="AUD — Đô-la Úc" },
            new LoaiTien() { ValueLoaiTien = "BDT", NameLoaiTien="BDT — Đồng Taka Bangladesh" },
            new LoaiTien() { ValueLoaiTien = "BOB", NameLoaiTien="BOB — Đồng Boliviano Bolivia" },
            new LoaiTien() { ValueLoaiTien = "BRL", NameLoaiTien="BRL — Đồng Real Brazil" },
            new LoaiTien() { ValueLoaiTien = "CAD", NameLoaiTien="CAD — Đô-la Canada" },
            new LoaiTien() { ValueLoaiTien = "CHF", NameLoaiTien="CHF — Đồng Franc Thụy Sĩ" },
            new LoaiTien() { ValueLoaiTien = "CLP", NameLoaiTien="CLP — Đồng Peso Chile" },
            new LoaiTien() { ValueLoaiTien = "CNY", NameLoaiTien="CNY — Đồng Nhân dân tệ Trung Quốc" },
            new LoaiTien() { ValueLoaiTien = "COP", NameLoaiTien="COP — Đồng Peso Colombia" },
            new LoaiTien() { ValueLoaiTien = "CRC", NameLoaiTien="CRC — Đồng Colón Costa Rica" },
            new LoaiTien() { ValueLoaiTien = "CZK", NameLoaiTien="CZK — Đồng Koruna Cộng hòa Séc" },
            new LoaiTien() { ValueLoaiTien = "DKK", NameLoaiTien="DKK — Đồng Krone Đan Mạch" },
            new LoaiTien() { ValueLoaiTien = "DZD", NameLoaiTien="DZD — Đồng Dinar Algeria" },
            new LoaiTien() { ValueLoaiTien = "EGP", NameLoaiTien="EGP — Đồng Bảng Ai Cập" },
            new LoaiTien() { ValueLoaiTien = "EUR", NameLoaiTien="EUR — Đồng Euro" },
            new LoaiTien() { ValueLoaiTien = "GBP", NameLoaiTien="GBP — Đồng Bảng Anh" },
            new LoaiTien() { ValueLoaiTien = "GTQ", NameLoaiTien="GTQ — Đồng Quetzal Guatemala" },
            new LoaiTien() { ValueLoaiTien = "HKD", NameLoaiTien="HKD — Đô-la Hồng Kông" },
            new LoaiTien() { ValueLoaiTien = "HNL", NameLoaiTien="HNL — Đồng Lempira Honduras" },
            new LoaiTien() { ValueLoaiTien = "HUF", NameLoaiTien="HUF — Đồng Forint Hungary" },
            new LoaiTien() { ValueLoaiTien = "IDR", NameLoaiTien="IDR — Đồng Rupiah Indonesia" },
            new LoaiTien() { ValueLoaiTien = "ILS", NameLoaiTien="ILS — Đồng New Shekel Israel" },
            new LoaiTien() { ValueLoaiTien = "INR", NameLoaiTien="INR — Đồng Rupee Ấn Độ" },
            new LoaiTien() { ValueLoaiTien = "ISK", NameLoaiTien="ISK — Đồng Krona Iceland" },
            new LoaiTien() { ValueLoaiTien = "JPY", NameLoaiTien="JPY — Đồng Yên Nhật" },
            new LoaiTien() { ValueLoaiTien = "KES", NameLoaiTien="KES — Đồng Shilling Kenya" },
            new LoaiTien() { ValueLoaiTien = "KRW", NameLoaiTien="KRW — Đồng Won Hàn Quốc" },
            new LoaiTien() { ValueLoaiTien = "MOP", NameLoaiTien="MOP — Đồng Patacas Ma Cao" },
            new LoaiTien() { ValueLoaiTien = "MXN", NameLoaiTien="MXN — Đồng Peso Mexico" },
            new LoaiTien() { ValueLoaiTien = "MYR", NameLoaiTien="MYR — Đồng Ringgit Malaysia" },
            new LoaiTien() { ValueLoaiTien = "NGN", NameLoaiTien="NGN — Đồng Naira Nigeria" },
            new LoaiTien() { ValueLoaiTien = "NIO", NameLoaiTien="NIO — Đồng Cordoba Nicaragua" },
            new LoaiTien() { ValueLoaiTien = "NOK", NameLoaiTien="NOK — Đồng Krone Na Uy" },
            new LoaiTien() { ValueLoaiTien = "NZD", NameLoaiTien="NZD — Đô-la New Zealand" },
            new LoaiTien() { ValueLoaiTien = "PEN", NameLoaiTien="PEN — Đồng Nuevo Sol Peru" },
            new LoaiTien() { ValueLoaiTien = "PHP", NameLoaiTien="PHP — Đồng Peso Philippin" },
            new LoaiTien() { ValueLoaiTien = "PKR", NameLoaiTien="PKR — Đồng Rupee Pakistan" },
            new LoaiTien() { ValueLoaiTien = "PLN", NameLoaiTien="PLN — Đồng Zloty Ba Lan" },
            new LoaiTien() { ValueLoaiTien = "PYG", NameLoaiTien="PYG — Đồng Guarani Paraguay" },
            new LoaiTien() { ValueLoaiTien = "QAR", NameLoaiTien="QAR — Đồng Rials Qatar" },
            new LoaiTien() { ValueLoaiTien = "RON", NameLoaiTien="RON — Đồng Leu Romania" },
            new LoaiTien() { ValueLoaiTien = "RUB", NameLoaiTien="RUB — Đồng Rúp Nga" },
            new LoaiTien() { ValueLoaiTien = "SAR", NameLoaiTien="SAR — Đồng Riyal Ả-rập Xê-út" },
            new LoaiTien() { ValueLoaiTien = "SEK", NameLoaiTien="SEK — Đồng Krona Thụy Điển" },
            new LoaiTien() { ValueLoaiTien = "SGD", NameLoaiTien="SGD — Đô-la Singapore" },
            new LoaiTien() { ValueLoaiTien = "THB", NameLoaiTien="THB — Đồng Baht Thái" },
            new LoaiTien() { ValueLoaiTien = "TRY", NameLoaiTien="TRY — Đồng Lira Thổ Nhĩ Kỳ" },
            new LoaiTien() { ValueLoaiTien = "TWD", NameLoaiTien="TWD — Đô-la Đài Loan" },
            new LoaiTien() { ValueLoaiTien = "UYU", NameLoaiTien="UYU — Đồng Peso Uruguay" },
            new LoaiTien() { ValueLoaiTien = "VND", NameLoaiTien="VND — Đồng Việt Nam" },
            new LoaiTien() { ValueLoaiTien = "ZAR", NameLoaiTien="ZAR — Đồng Rand Nam Phi" },
        };
        public List<QuocGia> danhSachQuocGia = new List<QuocGia>() {
            new QuocGia() { ValueQuocGia = "Ả-rập Xê-út", NameQuocGia="Ả-rập Xê-út" },
            new QuocGia() { ValueQuocGia = "Afghanistan", NameQuocGia="Afghanistan" },
            new QuocGia() { ValueQuocGia = "Ai Cập", NameQuocGia="Ai Cập" },
            new QuocGia() { ValueQuocGia = "Albania", NameQuocGia="Albania" },
            new QuocGia() { ValueQuocGia = "Algeria", NameQuocGia="Algeria" },
            new QuocGia() { ValueQuocGia = "Andorra", NameQuocGia="Andorra" },
            new QuocGia() { ValueQuocGia = "Angola", NameQuocGia="Angola" },
            new QuocGia() { ValueQuocGia = "Anguilla", NameQuocGia="Anguilla" },
            new QuocGia() { ValueQuocGia = "Antigua", NameQuocGia="Antigua" },
            new QuocGia() { ValueQuocGia = "Áo", NameQuocGia="Áo" },
            new QuocGia() { ValueQuocGia = "Argentina", NameQuocGia="Argentina" },
            new QuocGia() { ValueQuocGia = "Armenia", NameQuocGia="Armenia" },
            new QuocGia() { ValueQuocGia = "Aruba", NameQuocGia="Aruba" },
            new QuocGia() { ValueQuocGia = "Azerbaijan", NameQuocGia="Azerbaijan" },
            new QuocGia() { ValueQuocGia = "Ấn Độ", NameQuocGia="Ấn Độ" },
            new QuocGia() { ValueQuocGia = "Ba Lan", NameQuocGia="Ba Lan" },
            new QuocGia() { ValueQuocGia = "Bahamas", NameQuocGia="Bahamas" },
            new QuocGia() { ValueQuocGia = "Bahrain", NameQuocGia="Bahrain" },
            new QuocGia() { ValueQuocGia = "Bangladesh", NameQuocGia="Bangladesh" },
            new QuocGia() { ValueQuocGia = "Barbados", NameQuocGia="Barbados" },
            new QuocGia() { ValueQuocGia = "Belarus", NameQuocGia="Belarus" },
            new QuocGia() { ValueQuocGia = "Belize", NameQuocGia="Belize" },
            new QuocGia() { ValueQuocGia = "Benin", NameQuocGia="Benin" },
            new QuocGia() { ValueQuocGia = "Bermuda", NameQuocGia="Bermuda" },
            new QuocGia() { ValueQuocGia = "Bhutan", NameQuocGia="Bhutan" },
            new QuocGia() { ValueQuocGia = "Bỉ", NameQuocGia="Bỉ" },
            new QuocGia() { ValueQuocGia = "Bolivia", NameQuocGia="Bolivia" },
            new QuocGia() { ValueQuocGia = "Bosnia và Herzegovina", NameQuocGia="Bosnia và Herzegovina" },
            new QuocGia() { ValueQuocGia = "Botswana", NameQuocGia="Botswana" },
            new QuocGia() { ValueQuocGia = "Bồ Đào Nha", NameQuocGia="Bồ Đào Nha" },
            new QuocGia() { ValueQuocGia = "Bờ Biển Ngà", NameQuocGia="Bờ Biển Ngà" },
            new QuocGia() { ValueQuocGia = "Brazil", NameQuocGia="Brazil" },
            new QuocGia() { ValueQuocGia = "Brunei", NameQuocGia="Brunei" },
            new QuocGia() { ValueQuocGia = "Bulgaria", NameQuocGia="Bulgaria" },
            new QuocGia() { ValueQuocGia = "Burkina Faso", NameQuocGia="Burkina Faso" },
            new QuocGia() { ValueQuocGia = "Burundi", NameQuocGia="Burundi" },
            new QuocGia() { ValueQuocGia = "Các tiểu đảo xa của Hoa Kỳ", NameQuocGia="Các tiểu đảo xa của Hoa Kỳ" },
            new QuocGia() { ValueQuocGia = "Các Tiểu vương quốc Ả Rập Thống nhất", NameQuocGia="Các Tiểu vương quốc Ả Rập Thống nhất" },
            new QuocGia() { ValueQuocGia = "Cameroon", NameQuocGia="Cameroon" },
            new QuocGia() { ValueQuocGia = "Campuchia", NameQuocGia="Campuchia" },
            new QuocGia() { ValueQuocGia = "Canada", NameQuocGia="Canada" },
            new QuocGia() { ValueQuocGia = "Cape Verde", NameQuocGia="Cape Verde" },
            new QuocGia() { ValueQuocGia = "Chad", NameQuocGia="Chad" },
            new QuocGia() { ValueQuocGia = "Chile", NameQuocGia="Chile" },
            new QuocGia() { ValueQuocGia = "Colombia", NameQuocGia="Colombia" },
            new QuocGia() { ValueQuocGia = "Comoros", NameQuocGia="Comoros" },
            new QuocGia() { ValueQuocGia = "Costa Rica", NameQuocGia="Costa Rica" },
            new QuocGia() { ValueQuocGia = "Cộng hòa Congo", NameQuocGia="Cộng hòa Congo" },
            new QuocGia() { ValueQuocGia = "Cộng hòa Dân chủ Congo", NameQuocGia="Cộng hòa Dân chủ Congo" },
            new QuocGia() { ValueQuocGia = "Cộng hòa Dominica", NameQuocGia="Cộng hòa Dominica" },
            new QuocGia() { ValueQuocGia = "Cộng hòa Séc", NameQuocGia="Cộng hòa Séc" },
            new QuocGia() { ValueQuocGia = "Cộng hòa Togo", NameQuocGia="Cộng hòa Togo" },
            new QuocGia() { ValueQuocGia = "Cộng hòa Trung Phi", NameQuocGia="Cộng hòa Trung Phi" },
            new QuocGia() { ValueQuocGia = "Croatia", NameQuocGia="Croatia" },
            new QuocGia() { ValueQuocGia = "Cuba", NameQuocGia="Cuba" },
            new QuocGia() { ValueQuocGia = "Curaçao", NameQuocGia="Curaçao" },
            new QuocGia() { ValueQuocGia = "Djibouti", NameQuocGia="Djibouti" },
            new QuocGia() { ValueQuocGia = "Dominica", NameQuocGia="Dominica" },
            new QuocGia() { ValueQuocGia = "Đài Loan", NameQuocGia="Đài Loan" },
            new QuocGia() { ValueQuocGia = "Đan Mạch", NameQuocGia="Đan Mạch" },
            new QuocGia() { ValueQuocGia = "Đảo Bouvet", NameQuocGia="Đảo Bouvet" },
            new QuocGia() { ValueQuocGia = "Đảo Christmas", NameQuocGia="Đảo Christmas" },
            new QuocGia() { ValueQuocGia = "Đảo Heard và Quần đảo McDonald", NameQuocGia="Đảo Heard và Quần đảo McDonald" },
            new QuocGia() { ValueQuocGia = "Đảo Man", NameQuocGia="Đảo Man" },
            new QuocGia() { ValueQuocGia = "Đảo Norfolk", NameQuocGia="Đảo Norfolk" },
            new QuocGia() { ValueQuocGia = "Đông Timor", NameQuocGia="Đông Timor" },
            new QuocGia() { ValueQuocGia = "Đức", NameQuocGia="Đức" },
            new QuocGia() { ValueQuocGia = "Ecuador", NameQuocGia="Ecuador" },
            new QuocGia() { ValueQuocGia = "El Salvador", NameQuocGia="El Salvador" },
            new QuocGia() { ValueQuocGia = "Eritrea", NameQuocGia="Eritrea" },
            new QuocGia() { ValueQuocGia = "Estonia", NameQuocGia="Estonia" },
            new QuocGia() { ValueQuocGia = "Ethiopia", NameQuocGia="Ethiopia" },
            new QuocGia() { ValueQuocGia = "Fiji", NameQuocGia="Fiji" },
            new QuocGia() { ValueQuocGia = "Gabon", NameQuocGia="Gabon" },
            new QuocGia() { ValueQuocGia = "Gambia", NameQuocGia="Gambia" },
            new QuocGia() { ValueQuocGia = "Ghana", NameQuocGia="Ghana" },
            new QuocGia() { ValueQuocGia = "Gibraltar", NameQuocGia="Gibraltar" },
            new QuocGia() { ValueQuocGia = "Greenland", NameQuocGia="Greenland" },
            new QuocGia() { ValueQuocGia = "Grenada", NameQuocGia="Grenada" },
            new QuocGia() { ValueQuocGia = "Gruzia", NameQuocGia="Gruzia" },
            new QuocGia() { ValueQuocGia = "Guadeloupe", NameQuocGia="Guadeloupe" },
            new QuocGia() { ValueQuocGia = "Guam", NameQuocGia="Guam" },
            new QuocGia() { ValueQuocGia = "Guatemala", NameQuocGia="Guatemala" },
            new QuocGia() { ValueQuocGia = "Guernsey", NameQuocGia="Guernsey" },
            new QuocGia() { ValueQuocGia = "Guiana thuộc Pháp", NameQuocGia="Guiana thuộc Pháp" },
            new QuocGia() { ValueQuocGia = "Guinea", NameQuocGia="Guinea" },
            new QuocGia() { ValueQuocGia = "Guinea Xích đạo", NameQuocGia="Guinea Xích đạo" },
            new QuocGia() { ValueQuocGia = "Guinea-Bissau", NameQuocGia="Guinea-Bissau" },
            new QuocGia() { ValueQuocGia = "Guyana", NameQuocGia="Guyana" },
            new QuocGia() { ValueQuocGia = "Hà Lan", NameQuocGia="Hà Lan" },
            new QuocGia() { ValueQuocGia = "Haiti", NameQuocGia="Haiti" },
            new QuocGia() { ValueQuocGia = "Hàn Quốc", NameQuocGia="Hàn Quốc" },
            new QuocGia() { ValueQuocGia = "Hoa Kỳ", NameQuocGia="Hoa Kỳ" },
            new QuocGia() { ValueQuocGia = "Honduras", NameQuocGia="Honduras" },
            new QuocGia() { ValueQuocGia = "Hồng Kông", NameQuocGia="Hồng Kông" },
            new QuocGia() { ValueQuocGia = "Hungary", NameQuocGia="Hungary" },
            new QuocGia() { ValueQuocGia = "Hy Lạp", NameQuocGia="Hy Lạp" },
            new QuocGia() { ValueQuocGia = "Iceland", NameQuocGia="Iceland" },
            new QuocGia() { ValueQuocGia = "Indonesia", NameQuocGia="Indonesia" },
            new QuocGia() { ValueQuocGia = "Iran", NameQuocGia="Iran" },
            new QuocGia() { ValueQuocGia = "Iraq", NameQuocGia="Iraq" },
            new QuocGia() { ValueQuocGia = "Ireland", NameQuocGia="Ireland" },
            new QuocGia() { ValueQuocGia = "Israel", NameQuocGia="Israel" },
            new QuocGia() { ValueQuocGia = "Jamaica", NameQuocGia="Jamaica" },
            new QuocGia() { ValueQuocGia = "Jersey", NameQuocGia="Jersey" },
            new QuocGia() { ValueQuocGia = "Jordan", NameQuocGia="Jordan" },
            new QuocGia() { ValueQuocGia = "Kazakhstan", NameQuocGia="Kazakhstan" },
            new QuocGia() { ValueQuocGia = "Kenya", NameQuocGia="Kenya" },
            new QuocGia() { ValueQuocGia = "Kiribati", NameQuocGia="Kiribati" },
            new QuocGia() { ValueQuocGia = "Kosovo", NameQuocGia="Kosovo" },
            new QuocGia() { ValueQuocGia = "Kuwait", NameQuocGia="Kuwait" },
            new QuocGia() { ValueQuocGia = "Kyrgyzstan", NameQuocGia="Kyrgyzstan" },
            new QuocGia() { ValueQuocGia = "Lãnh thổ Ấn Độ Dương thuộc Anh", NameQuocGia="Lãnh thổ Ấn Độ Dương thuộc Anh" },
            new QuocGia() { ValueQuocGia = "Lào", NameQuocGia="Lào" },
            new QuocGia() { ValueQuocGia = "Latvia", NameQuocGia="Latvia" },
            new QuocGia() { ValueQuocGia = "Lesotho", NameQuocGia="Lesotho" },
            new QuocGia() { ValueQuocGia = "Li Băng", NameQuocGia="Li Băng" },
            new QuocGia() { ValueQuocGia = "Liberia", NameQuocGia="Liberia" },
            new QuocGia() { ValueQuocGia = "Liechtenstein", NameQuocGia="Liechtenstein" },
            new QuocGia() { ValueQuocGia = "Liên bang Micronesia", NameQuocGia="Liên bang Micronesia" },
            new QuocGia() { ValueQuocGia = "Lithuania", NameQuocGia="Lithuania" },
            new QuocGia() { ValueQuocGia = "Luxembourg", NameQuocGia="Luxembourg" },
            new QuocGia() { ValueQuocGia = "Lybia", NameQuocGia="Lybia" },
            new QuocGia() { ValueQuocGia = "Ma Cao", NameQuocGia="Ma Cao" },
            new QuocGia() { ValueQuocGia = "Ma-rốc", NameQuocGia="Ma-rốc" },
            new QuocGia() { ValueQuocGia = "Macedonia", NameQuocGia="Macedonia" },
            new QuocGia() { ValueQuocGia = "Madagascar", NameQuocGia="Madagascar" },
            new QuocGia() { ValueQuocGia = "Malawi", NameQuocGia="Malawi" },
            new QuocGia() { ValueQuocGia = "Malaysia", NameQuocGia="Malaysia" },
            new QuocGia() { ValueQuocGia = "Maldives", NameQuocGia="Maldives" },
            new QuocGia() { ValueQuocGia = "Mali", NameQuocGia="Mali" },
            new QuocGia() { ValueQuocGia = "Malta", NameQuocGia="Malta" },
            new QuocGia() { ValueQuocGia = "Martinique", NameQuocGia="Martinique" },
            new QuocGia() { ValueQuocGia = "Mauritania", NameQuocGia="Mauritania" },
            new QuocGia() { ValueQuocGia = "Mauritius", NameQuocGia="Mauritius" },
            new QuocGia() { ValueQuocGia = "Mayotte", NameQuocGia="Mayotte" },
            new QuocGia() { ValueQuocGia = "Mexico", NameQuocGia="Mexico" },
            new QuocGia() { ValueQuocGia = "Moldova", NameQuocGia="Moldova" },
            new QuocGia() { ValueQuocGia = "Monaco", NameQuocGia="Monaco" },
            new QuocGia() { ValueQuocGia = "Montenegro", NameQuocGia="Montenegro" },
            new QuocGia() { ValueQuocGia = "Montserrat", NameQuocGia="Montserrat" },
            new QuocGia() { ValueQuocGia = "Mozambique", NameQuocGia="Mozambique" },
            new QuocGia() { ValueQuocGia = "Mông Cổ", NameQuocGia="Mông Cổ" },
            new QuocGia() { ValueQuocGia = "Myanmar", NameQuocGia="Myanmar" },
            new QuocGia() { ValueQuocGia = "Na Uy", NameQuocGia="Na Uy" },
            new QuocGia() { ValueQuocGia = "Nam Cực", NameQuocGia="Nam Cực" },
            new QuocGia() { ValueQuocGia = "Nam Phi", NameQuocGia="Nam Phi" },
            new QuocGia() { ValueQuocGia = "Nam Sudan", NameQuocGia="Nam Sudan" },
            new QuocGia() { ValueQuocGia = "Namibia", NameQuocGia="Namibia" },
            new QuocGia() { ValueQuocGia = "Nauru", NameQuocGia="Nauru" },
            new QuocGia() { ValueQuocGia = "Nepal", NameQuocGia="Nepal" },
            new QuocGia() { ValueQuocGia = "Netherlands Antilles", NameQuocGia="Netherlands Antilles" },
            new QuocGia() { ValueQuocGia = "New Caledonia", NameQuocGia="New Caledonia" },
            new QuocGia() { ValueQuocGia = "New Zealand", NameQuocGia="New Zealand" },
            new QuocGia() { ValueQuocGia = "Nga", NameQuocGia="Nga" },
            new QuocGia() { ValueQuocGia = "Nhật Bản", NameQuocGia="Nhật Bản" },
            new QuocGia() { ValueQuocGia = "Nicaragua", NameQuocGia="Nicaragua" },
            new QuocGia() { ValueQuocGia = "Niger", NameQuocGia="Niger" },
            new QuocGia() { ValueQuocGia = "Nigeria", NameQuocGia="Nigeria" },
            new QuocGia() { ValueQuocGia = "Niue", NameQuocGia="Niue" },
            new QuocGia() { ValueQuocGia = "Oman", NameQuocGia="Oman" },
            new QuocGia() { ValueQuocGia = "Pakistan", NameQuocGia="Pakistan" },
            new QuocGia() { ValueQuocGia = "Palau", NameQuocGia="Palau" },
            new QuocGia() { ValueQuocGia = "Palestine", NameQuocGia="Palestine" },
            new QuocGia() { ValueQuocGia = "Panama", NameQuocGia="Panama" },
            new QuocGia() { ValueQuocGia = "Papua New Guinea", NameQuocGia="Papua New Guinea" },
            new QuocGia() { ValueQuocGia = "Paraguay", NameQuocGia="Paraguay" },
            new QuocGia() { ValueQuocGia = "Peru", NameQuocGia="Peru" },
            new QuocGia() { ValueQuocGia = "Pháp", NameQuocGia="Pháp" },
            new QuocGia() { ValueQuocGia = "Phần Lan", NameQuocGia="Phần Lan" },
            new QuocGia() { ValueQuocGia = "Philippin", NameQuocGia="Philippin" },
            new QuocGia() { ValueQuocGia = "Pitcairn", NameQuocGia="Pitcairn" },
            new QuocGia() { ValueQuocGia = "Polynesia thuộc Pháp", NameQuocGia="Polynesia thuộc Pháp" },
            new QuocGia() { ValueQuocGia = "Puerto Rico", NameQuocGia="Puerto Rico" },
            new QuocGia() { ValueQuocGia = "Qatar", NameQuocGia="Qatar" },
            new QuocGia() { ValueQuocGia = "Quần đảo Aland", NameQuocGia="Quần đảo Aland" },
            new QuocGia() { ValueQuocGia = "Quần đảo Bắc Mariana", NameQuocGia="Quần đảo Bắc Mariana" },
            new QuocGia() { ValueQuocGia = "Quần đảo Cayman", NameQuocGia="Quần đảo Cayman" },
            new QuocGia() { ValueQuocGia = "Quần đảo Cocos (Keeling)", NameQuocGia="Quần đảo Cocos (Keeling)" },
            new QuocGia() { ValueQuocGia = "Quần đảo Cook", NameQuocGia="Quần đảo Cook" },
            new QuocGia() { ValueQuocGia = "Quần đảo Falkland", NameQuocGia="Quần đảo Falkland" },
            new QuocGia() { ValueQuocGia = "Quần đảo Faroe", NameQuocGia="Quần đảo Faroe" },
            new QuocGia() { ValueQuocGia = "Quần đảo Marshall", NameQuocGia="Quần đảo Marshall" },
            new QuocGia() { ValueQuocGia = "Quần đảo Nam Georgia và Nam Sandwich", NameQuocGia="Quần đảo Nam Georgia và Nam Sandwich" },
            new QuocGia() { ValueQuocGia = "Quần đảo Solomon", NameQuocGia="Quần đảo Solomon" },
            new QuocGia() { ValueQuocGia = "Quần đảo Turks và Caicos", NameQuocGia="Quần đảo Turks và Caicos" },
            new QuocGia() { ValueQuocGia = "Quần đảo Virgin thuộc Anh", NameQuocGia="Quần đảo Virgin thuộc Anh" },
            new QuocGia() { ValueQuocGia = "Quần đảo Virgin thuộc Mỹ", NameQuocGia="Quần đảo Virgin thuộc Mỹ" },
            new QuocGia() { ValueQuocGia = "Réunion", NameQuocGia="Réunion" },
            new QuocGia() { ValueQuocGia = "Romania", NameQuocGia="Romania" },
            new QuocGia() { ValueQuocGia = "Rwanda", NameQuocGia="Rwanda" },
            new QuocGia() { ValueQuocGia = "Saint Barthélemy", NameQuocGia="Saint Barthélemy" },
            new QuocGia() { ValueQuocGia = "Saint Helena", NameQuocGia="Saint Helena" },
            new QuocGia() { ValueQuocGia = "Saint Kitts và Nevis", NameQuocGia="Saint Kitts và Nevis" },
            new QuocGia() { ValueQuocGia = "Saint Martin", NameQuocGia="Saint Martin" },
            new QuocGia() { ValueQuocGia = "Saint Pierre và Miquelon", NameQuocGia="Saint Pierre và Miquelon" },
            new QuocGia() { ValueQuocGia = "Saint Vincent và Grenadines", NameQuocGia="Saint Vincent và Grenadines" },
            new QuocGia() { ValueQuocGia = "Samoa", NameQuocGia="Samoa" },
            new QuocGia() { ValueQuocGia = "Samoa thuộc Mỹ", NameQuocGia="Samoa thuộc Mỹ" },
            new QuocGia() { ValueQuocGia = "San Marino", NameQuocGia="San Marino" },
            new QuocGia() { ValueQuocGia = "Sao Tome và Principe", NameQuocGia="Sao Tome và Principe" },
            new QuocGia() { ValueQuocGia = "Senegal", NameQuocGia="Senegal" },
            new QuocGia() { ValueQuocGia = "Serbia", NameQuocGia="Serbia" },
            new QuocGia() { ValueQuocGia = "Seychelles", NameQuocGia="Seychelles" },
            new QuocGia() { ValueQuocGia = "Sierra Leone", NameQuocGia="Sierra Leone" },
            new QuocGia() { ValueQuocGia = "Singapore", NameQuocGia="Singapore" },
            new QuocGia() { ValueQuocGia = "Síp", NameQuocGia="Síp" },
            new QuocGia() { ValueQuocGia = "Slovakia", NameQuocGia="Slovakia" },
            new QuocGia() { ValueQuocGia = "Slovenia", NameQuocGia="Slovenia" },
            new QuocGia() { ValueQuocGia = "Somalia", NameQuocGia="Somalia" },
            new QuocGia() { ValueQuocGia = "Sri Lanka", NameQuocGia="Sri Lanka" },
            new QuocGia() { ValueQuocGia = "St. Lucia", NameQuocGia="St. Lucia" },
            new QuocGia() { ValueQuocGia = "Sudan", NameQuocGia="Sudan" },
            new QuocGia() { ValueQuocGia = "Suriname", NameQuocGia="Suriname" },
            new QuocGia() { ValueQuocGia = "Svalbard và Jan Mayen", NameQuocGia="Svalbard và Jan Mayen" },
            new QuocGia() { ValueQuocGia = "Swaziland", NameQuocGia="Swaziland" },
            new QuocGia() { ValueQuocGia = "Syria", NameQuocGia="Syria" },
            new QuocGia() { ValueQuocGia = "Tajikistan", NameQuocGia="Tajikistan" },
            new QuocGia() { ValueQuocGia = "Tanzania", NameQuocGia="Tanzania" },
            new QuocGia() { ValueQuocGia = "Tây Ban Nha", NameQuocGia="Tây Ban Nha" },
            new QuocGia() { ValueQuocGia = "Tây Sahara", NameQuocGia="Tây Sahara" },
            new QuocGia() { ValueQuocGia = "Thái Lan", NameQuocGia="Thái Lan" },
            new QuocGia() { ValueQuocGia = "Thành Vatican", NameQuocGia="Thành Vatican" },
            new QuocGia() { ValueQuocGia = "Thổ Nhĩ Kỳ", NameQuocGia="Thổ Nhĩ Kỳ" },
            new QuocGia() { ValueQuocGia = "Thụy Điển", NameQuocGia="Thụy Điển" },
            new QuocGia() { ValueQuocGia = "Thụy Sỹ", NameQuocGia="Thụy Sỹ" },
            new QuocGia() { ValueQuocGia = "Tokelau", NameQuocGia="Tokelau" },
            new QuocGia() { ValueQuocGia = "Tonga", NameQuocGia="Tonga" },
            new QuocGia() { ValueQuocGia = "Triều Tiên", NameQuocGia="Triều Tiên" },
            new QuocGia() { ValueQuocGia = "Trinidad và Tobago", NameQuocGia="Trinidad và Tobago" },
            new QuocGia() { ValueQuocGia = "Trung Quốc", NameQuocGia="Trung Quốc" },
            new QuocGia() { ValueQuocGia = "Tunisia", NameQuocGia="Tunisia" },
            new QuocGia() { ValueQuocGia = "Turkmenistan", NameQuocGia="Turkmenistan" },
            new QuocGia() { ValueQuocGia = "Tuvalu", NameQuocGia="Tuvalu" },
            new QuocGia() { ValueQuocGia = "Úc", NameQuocGia="Úc" },
            new QuocGia() { ValueQuocGia = "Uganda", NameQuocGia="Uganda" },
            new QuocGia() { ValueQuocGia = "Ukraine", NameQuocGia="Ukraine" },
            new QuocGia() { ValueQuocGia = "Uruguay", NameQuocGia="Uruguay" },
            new QuocGia() { ValueQuocGia = "Uzbekistan", NameQuocGia="Uzbekistan" },
            new QuocGia() { ValueQuocGia = "Vanuatu", NameQuocGia="Vanuatu" },
            new QuocGia() { ValueQuocGia = "Venezuela", NameQuocGia="Venezuela" },
            new QuocGia() { ValueQuocGia = "Việt Nam", NameQuocGia="Việt Nam" },
            new QuocGia() { ValueQuocGia = "Vùng đất phía Nam thuộc Pháp", NameQuocGia="Vùng đất phía Nam thuộc Pháp" },
            new QuocGia() { ValueQuocGia = "Vương quốc Anh", NameQuocGia="Vương quốc Anh" },
            new QuocGia() { ValueQuocGia = "Wallis và Futuna", NameQuocGia="Wallis và Futuna" },
            new QuocGia() { ValueQuocGia = "Ý", NameQuocGia="Ý" },
            new QuocGia() { ValueQuocGia = "Yemen", NameQuocGia="Yemen" },
            new QuocGia() { ValueQuocGia = "Zambia", NameQuocGia="Zambia" },
            new QuocGia() { ValueQuocGia = "Zimbabwe", NameQuocGia="Zimbabwe" },
        };
        public List<TienTe> danhSachTienTe = new List<TienTe>() {
            new TienTe() { ValueTienTe = "Đồng Dirham UAE", NameTienTe="Đồng Dirham UAE" },
            new TienTe() { ValueTienTe = "Đồng Peso Argentina", NameTienTe="Đồng Peso Argentina" },
            new TienTe() { ValueTienTe = "Đô-la Úc", NameTienTe="Đô-la Úc" },
            new TienTe() { ValueTienTe = "Đồng Taka Bangladesh", NameTienTe="Đồng Taka Bangladesh" },
            new TienTe() { ValueTienTe = "Đồng Boliviano Bolivia", NameTienTe="Đồng Boliviano Bolivia" },
            new TienTe() { ValueTienTe = "Đồng Real Brazil", NameTienTe="Đồng Real Brazil" },
            new TienTe() { ValueTienTe = "Đô-la Canada", NameTienTe="Đô-la Canada" },
            new TienTe() { ValueTienTe = "Đồng Franc Thụy Sĩ", NameTienTe="Đồng Franc Thụy Sĩ" },
            new TienTe() { ValueTienTe = "Đồng Peso Chile", NameTienTe="Đồng Peso Chile" },
            new TienTe() { ValueTienTe = "Đồng Nhân dân tệ Trung Quốc", NameTienTe="Đồng Nhân dân tệ Trung Quốc" },
            new TienTe() { ValueTienTe = "Đồng Peso Colombia", NameTienTe="Đồng Peso Colombia" },
            new TienTe() { ValueTienTe = "Đồng Colón Costa Rica", NameTienTe="Đồng Colón Costa Rica" },
            new TienTe() { ValueTienTe = "Đồng Koruna Cộng hòa Séc", NameTienTe="Đồng Koruna Cộng hòa Séc" },
            new TienTe() { ValueTienTe = "Đồng Krone Đan Mạch", NameTienTe="Đồng Krone Đan Mạch" },
            new TienTe() { ValueTienTe = "Đồng Dinar Algeria", NameTienTe="Đồng Dinar Algeria" },
            new TienTe() { ValueTienTe = "Đồng Bảng Ai Cập", NameTienTe="Đồng Bảng Ai Cập" },
            new TienTe() { ValueTienTe = "Đồng Euro", NameTienTe="Đồng Euro" },
            new TienTe() { ValueTienTe = "Đồng Bảng Anh", NameTienTe="Đồng Bảng Anh" },
            new TienTe() { ValueTienTe = "Đồng Quetzal Guatemala", NameTienTe="Đồng Quetzal Guatemala" },
            new TienTe() { ValueTienTe = "Đô-la Hồng Kông", NameTienTe="Đô-la Hồng Kông" },
            new TienTe() { ValueTienTe = "Đồng Lempira Honduras", NameTienTe="Đồng Lempira Honduras" },
            new TienTe() { ValueTienTe = "Đồng Forint Hungary", NameTienTe="Đồng Forint Hungary" },
            new TienTe() { ValueTienTe = "Đồng Rupiah Indonesia", NameTienTe="Đồng Rupiah Indonesia" },
            new TienTe() { ValueTienTe = "Đồng New Shekel Israel", NameTienTe="Đồng New Shekel Israel" },
            new TienTe() { ValueTienTe = "Đồng Rupee Ấn Độ", NameTienTe="Đồng Rupee Ấn Độ" },
            new TienTe() { ValueTienTe = "Đồng Krona Iceland", NameTienTe="Đồng Krona Iceland" },
            new TienTe() { ValueTienTe = "Đồng Yên Nhật", NameTienTe="Đồng Yên Nhật" },
            new TienTe() { ValueTienTe = "Đồng Shilling Kenya", NameTienTe="Đồng Shilling Kenya" },
            new TienTe() { ValueTienTe = "Đồng Won Hàn Quốc", NameTienTe="Đồng Won Hàn Quốc" },
            new TienTe() { ValueTienTe = "Đồng Patacas Ma Cao", NameTienTe="Đồng Patacas Ma Cao" },
            new TienTe() { ValueTienTe = "Đồng Peso Mexico", NameTienTe="Đồng Peso Mexico" },
            new TienTe() { ValueTienTe = "Đồng Ringgit Malaysia", NameTienTe="Đồng Ringgit Malaysia" },
            new TienTe() { ValueTienTe = "Đồng Naira Nigeria", NameTienTe="Đồng Naira Nigeria" },
            new TienTe() { ValueTienTe = "Đồng Cordoba Nicaragua", NameTienTe="Đồng Cordoba Nicaragua" },
            new TienTe() { ValueTienTe = "Đồng Krone Na Uy", NameTienTe="Đồng Krone Na Uy" },
            new TienTe() { ValueTienTe = "Đô-la New Zealand", NameTienTe="Đô-la New Zealand" },
            new TienTe() { ValueTienTe = "Đồng Nuevo Sol Peru", NameTienTe="Đồng Nuevo Sol Peru" },
            new TienTe() { ValueTienTe = "Đồng Peso Philippin", NameTienTe="Đồng Peso Philippin" },
            new TienTe() { ValueTienTe = "Đồng Rupee Pakistan", NameTienTe="Đồng Rupee Pakistan" },
            new TienTe() { ValueTienTe = "Đồng Zloty Ba Lan", NameTienTe="Đồng Zloty Ba Lan" },
            new TienTe() { ValueTienTe = "Đồng Guarani Paraguay", NameTienTe="Đồng Guarani Paraguay" },
            new TienTe() { ValueTienTe = "Đồng Rials Qatar", NameTienTe="Đồng Rials Qatar" },
            new TienTe() { ValueTienTe = "Đồng Leu Romania", NameTienTe="Đồng Leu Romania" },
            new TienTe() { ValueTienTe = "Đồng Rúp Nga", NameTienTe="Đồng Rúp Nga" },
            new TienTe() { ValueTienTe = "Đồng Riyal Ả-rập Xê-út", NameTienTe="Đồng Riyal Ả-rập Xê-út" },
            new TienTe() { ValueTienTe = "Đồng Krona Thụy Điển", NameTienTe="Đồng Krona Thụy Điển" },
            new TienTe() { ValueTienTe = "Đô-la Singapore", NameTienTe="Đô-la Singapore" },
            new TienTe() { ValueTienTe = "Đồng Baht Thái", NameTienTe="Đồng Baht Thái" },
            new TienTe() { ValueTienTe = "Đồng Lira Thổ Nhĩ Kỳ", NameTienTe="Đồng Lira Thổ Nhĩ Kỳ" },
            new TienTe() { ValueTienTe = "Đô-la Đài Loan", NameTienTe="Đô-la Đài Loan" },
            new TienTe() { ValueTienTe = "Đô la Mỹ", NameTienTe="Đô la Mỹ" },
            new TienTe() { ValueTienTe = "Đồng Peso Uruguay", NameTienTe="Đồng Peso Uruguay" },
            new TienTe() { ValueTienTe = "Đồng Việt Nam", NameTienTe="Đồng Việt Nam" },
            new TienTe() { ValueTienTe = "Đồng Rand Nam Phi", NameTienTe="Đồng Rand Nam Phi" },
        };
        IWebDriver dr;
        Random random = new Random();
        public string RandomString(int length)
        { 
            const string chars = "qwertyu iopasdfg hjklzxcvbnm ABCDEFGHIJK LMNOPQRS TUVWXY Z0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        NotifiableCollection<Model> danhSachCookie = new NotifiableCollection<Model>();
        public MainWindow()
        {
            ClearMemory();
            CloseAllTabChrome();
            InitializeComponent();
            dataGridDanhSachTaiKhoan.DataContext = danhSachCookie;
            stMuiGio.DataContext = danhSachMuiGio;
            stLoaiTien.DataContext = danhSachLoaiTien;
            stQuocGiaLapHoaDon.DataContext = danhSachQuocGia;
            stTienTe.DataContext = danhSachTienTe;

        }
        public void CloseAllTabChrome()
        {
            Process[] chromeInstances = Process.GetProcessesByName("chrome");
            foreach (Process p in chromeInstances)
            {
                try
                {
                    p.Kill();
                }
                catch
                {
                }
            }
        }
        public void ClearMemory()
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                try
                {
                    chromeDriverProcess.Kill();
                }
                catch
                {
                }
            }
        }
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            InputDataLogin inputDataLogin = new InputDataLogin(true);
            inputDataLogin.Chon += (_sender, _args) =>
            {
                string dataCallback = (_sender as InputDataLogin).txtDataInput.Text;
                List<string> ds = dataCallback.Split(new char[] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var item in ds)
                {
                    danhSachCookie.Add(new Model() { Name = item, TrangThai = "Đang chờ!!" });
                }
                (_sender as InputDataLogin).Close();
            };
            inputDataLogin.ShowDialog();
        }
        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            RunMain();
            if (dr != null)
            {
                dr.Close();
                dr.Quit();
            }
        }
        public async void RunMain()
        {
            foreach (var item in danhSachCookie)
            {
               await Task.Run(() => { Run(item); });
                ClearMemory();
                CloseAllTabChrome();
            }
        }
        public void Run(Model model)
        {
            model.TrangThai = "Đang tạo BM";
            var getMail = new GetEmail(this.dr);
            getMail.SetCookies(model.Name);
            if (getMail.RunGetMail())
            {
                getMail.TaoBussiness(getMail.Email);
                model.TrangThai = getMail.Email;
                return;
            }
            else
            {
                model.TrangThai = getMail.Email;
                return;
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            CloseAllTabChrome();
            ClearMemory();
        }
        public void ResetText()
        {
            txtSoThe.Text = "";
            txtThang.Text = "";
            txtNam.Text = "";
            txtCookie.Text = "";
            txtPass.Password = "";
            txtTenTaiKhoanQuangCao.Text = "";
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do developer làm biếng check code nên:" + Environment.NewLine + 
                "Hãy đảm bảo rằng các thông tin đã nhập chính xác !", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                danhSachCookie.Add(new Model() {
                    Name = txtCookie.Text,
                    TrangThai = "Đang chờ",
                    SoThe = txtSoThe.Text,
                    Thang = txtThang.Text,
                    Nam = txtNam.Text,
                    MaBaoMat = txtPass.Password,
                    TenTaiKhoanQuangCao = txtTenTaiKhoanQuangCao.Text,
                    _MuiGio = cbbMuiGio.SelectedItem as MuiGio,
                    _QuocGia = cbbQuocGiaLapHoaDon.SelectedItem as QuocGia,
                    _TienTe = cbbTienTe.SelectedItem as TienTe,
                    _LoaiTien = cbbLoaiTien.SelectedItem as LoaiTien
                });
                ResetText();
            }
        }
    }
}