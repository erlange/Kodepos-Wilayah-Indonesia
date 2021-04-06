# Kodepos Wilayah Administratif Indonesia

## Daftar Isi
* [**Unduhan**](#Unduhan)
* [**Penjelasan**](#Penjelasan)
* [**Referensi**](#Referensi)


## Unduhan
* [📁 CSV](https://github.com/erlange/Kodepos-Wilayah-Indonesia/tree/master/csv)
  * [🗄 DT1.csv](https://raw.githubusercontent.com/erlange/Kodepos-Wilayah-Indonesia/master/csv/DT1.csv)
  * [🗄 dt2.csv](https://raw.githubusercontent.com/erlange/Kodepos-Wilayah-Indonesia/master/csv/dt2.csv)
  * [🗄 dt3.csv](https://raw.githubusercontent.com/erlange/Kodepos-Wilayah-Indonesia/master/csv/dt3.csv)
  * [🗄 dt4.csv](https://raw.githubusercontent.com/erlange/Kodepos-Wilayah-Indonesia/master/csv/dt4.csv)
* [📁 SQL Database](https://github.com/erlange/Kodepos-Wilayah-Indonesia/tree/master/db)
  * [📁 MSSQL](https://github.com/erlange/Kodepos-Wilayah-Indonesia/tree/master/db/MSSQL)
    * [🗄 datif.sql](https://raw.githubusercontent.com/erlange/Kodepos-Wilayah-Indonesia/master/db/MSSQL/datif.sql)
    * [🗄 rekap.sql](https://raw.githubusercontent.com/erlange/Kodepos-Wilayah-Indonesia/master/db/MSSQL/rekap.sql)
  * [📁 MariaDB/MySQL](https://github.com/erlange/Kodepos-Wilayah-Indonesia/tree/master/db/MariaDB)
    * [🗄 datif.sql](https://raw.githubusercontent.com/erlange/Kodepos-Wilayah-Indonesia/master/db/MariaDB/datif.sql)
* [📁 JSON](https://github.com/erlange/Kodepos-Wilayah-Indonesia/tree/master/json)
    * [🗄 kodepos.simple.json](https://raw.githubusercontent.com/erlange/Kodepos-Wilayah-Indonesia/master/json/kodepos.simple.json)
    * [🗄 kodepos.extended.json](https://raw.githubusercontent.com/erlange/Kodepos-Wilayah-Indonesia/master/json/kodepos.extended.json)

## Penjelasan
Data wilayah administratif Indonesia berdasarkan Permendagri No.137 Tahun 2017 beserta kode pos di tingkat IV (desa/kecamatan).

| **NO** | **KODE** | **PROPINSI**                  | **KOTA** | **KABUPATEN** | **KECAMATAN** | **DESA/KELURAHAN** |
|---:|-----:|---------------------------|-----:|----------:|----------:|----------:|
|    |      |        **TOTAL NASIONAL** |   **98** |       **416** |      **7201** |     **83436** |
| 1  | 11   | Aceh (NAD)                |    5 |        18 |       289 |      6497 |
| 2  | 12   | Sumatera Utara            |    8 |        25 |       444 |      6110 |
| 3  | 13   | Sumatera Barat            |    7 |        12 |       179 |      1158 |
| 4  | 14   | Riau                      |    2 |        10 |       166 |      1859 |
| 5  | 15   | Jambi                     |    2 |         9 |       141 |      1562 |
| 6  | 16   | Sumatera Selatan          |    4 |        13 |       236 |      3239 |
| 7  | 17   | Bengkulu                  |    1 |         9 |       128 |      1513 |
| 8  | 18   | Lampung                   |    2 |        13 |       228 |      2640 |
| 9  | 19   | Kepulauan Bangka Belitung |    1 |         6 |        47 |       391 |
| 10 | 21   | Kepulauan Riau            |    2 |         5 |        70 |       416 |
| 11 | 31   | DKI Jakarta               |    5 |         1 |        44 |       267 |
| 12 | 32   | Jawa Barat                |    9 |        18 |       627 |      5957 |
| 13 | 33   | Jawa Tengah               |    6 |        29 |       573 |      8559 |
| 14 | 34   | DI Yogyakarta             |    1 |         4 |        78 |       438 |
| 15 | 35   | Jawa Timur                |    9 |        29 |       666 |      8501 |
| 16 | 36   | Banten                    |    4 |         4 |       155 |      1551 |
| 17 | 51   | Bali                      |    1 |         8 |        57 |       716 |
| 18 | 52   | Nusa Tenggara Barat (NTB) |    2 |         8 |       116 |      1137 |
| 19 | 53   | Nusa Tenggara Timur (NTT) |    1 |        21 |       309 |      3353 |
| 20 | 61   | Kalimantan Barat          |    2 |        12 |       174 |      2130 |
| 21 | 62   | Kalimantan Tengah         |    1 |        13 |       136 |      1571 |
| 22 | 63   | Kalimantan Selatan        |    2 |        11 |       153 |      2008 |
| 23 | 64   | Kalimantan Timur          |    3 |         7 |       103 |      1038 |
| 24 | 65   | Kalimantan Utara          |    1 |         4 |        53 |       482 |
| 25 | 71   | Sulawesi Utara            |    4 |        11 |       171 |      1839 |
| 26 | 72   | Sulawesi Tengah           |    1 |        12 |       175 |      2017 |
| 27 | 73   | Sulawesi Selatan          |    3 |        21 |       307 |      3047 |
| 28 | 74   | Sulawesi Tenggara         |    2 |        15 |       219 |      2292 |
| 29 | 75   | Gorontalo                 |    1 |         5 |        77 |       729 |
| 30 | 76   | Sulawesi Barat            |    0 |         6 |        69 |       648 |
| 31 | 81   | Maluku                    |    2 |         9 |       118 |      1233 |
| 32 | 82   | Maluku Utara              |    2 |         8 |       115 |      1180 |
| 33 | 91   | Papua                     |    1 |        28 |       560 |      5521 |
| 34 | 92   | Papua Barat               |    1 |        12 |       218 |      1837 |


## Referensi

Kode dan Data Wilayah Administrasi Pemerintahan berdasarkan [Permendagri No.137 Tahun 2017](https://www.kemendagri.go.id/page/read/40/permendagri-no137-tahun-2017).