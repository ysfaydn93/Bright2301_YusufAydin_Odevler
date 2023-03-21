//#region SORU 1

// 1) Verilen url ve ders adı bilgisini kullanarak aşağıdaki işlemleri yapınız.
// url="https://www.wissenakademie.com";
// dersAdi="Fullstack Web Developer Eğitimi";

// let url = "https://www.wissenakademie.com";
// let dersAdi = "Fullstack Web Developer Eğitimi";

// console ile çözüm

// url kaç karakterlidir?
// console.log(url.length);

// ders adı kaç kelimeden oluşmaktadır?
// console.log(dersAdi.split(" "));

// url https ile başlıyor mu?
// console.log(url.startsWith("https"));

// ders adı içinde Eğitimi kelimesi geçiyor mu?
// console.log(dersAdi.includes("Eğitimi"));



// url ve ders adını kullanarak aşağıdaki string ifadeyi oluşturun:
// https://www.wissenakademie.com/fullstack-web-gelistirme-egitimi

// dersAdi = dersAdi.replaceAll("Developer","Geliştirme");
// dersAdi = dersAdi.toLowerCase();
// dersAdi = dersAdi.replaceAll(" ","-");
// dersAdi = dersAdi.replace("ı","i").replace("ş","s");

// console.log(`${url}/${dersAdi}`);

// degiskenle cozum

// let sonuc = url.length;
// console.log(sonuc);

//#endregion

//#region SORU 2

// 1- "Elma,Armut,Muz,Çilek" elemanlarına sahip bir dizi oluşturunuz.
// let meyveler = ["Elma", "Armut", "Muz", "Çilek"];

// let meyveler1=[];
// meyveler1[0]="Elma"
// meyveler1[1]="Armut"
// meyveler1[2]="Muz"
// meyveler1[3]="Çilek"

// 2- Dizi kaç elemanlıdır?
// console.log(meyveler.length);

// 3- Dizinin ilk ve son elemanı nedir?
// console.log(`Meyveler dizisinin ilk elemanı : ${meyveler[0]} \n Meyveler dizisinin son elemanı : ${meyveler[meyveler.length-1]}`);

// 4- Elma dizinin bir elemanımıdır?
// console.log(meyveler.includes("Elma"));

// 5- Kiraz meyvesini listenin sonuna ekleyiniz.
// console.log(meyveler.push("Kiraz"));
// console.log(meyveler);

// basına eklemek istersen unshift

// 6- Dizinin son 2 elemanını siliniz.
// en son 2 elemanı sildi
// console.log(meyveler.splice(3,2));
// console.log(meyveler);

// 7- Aşağıdaki bilgileri dizi içerisinde saklayınız ve her öğrencinin yaşını ve not ortalamasını hesaplayınız.
//
//         Öğrenci 1: Kemal Devrimdar 2010 (70,60,80)
//         Öğrenci 2: Saliha Temel 2012   (80,80,90)
//         Öğrenci 3: Defne Küp  2009 (60,60,70)


// let ogr1 = ["Kerim Devrimdar", 2010, [70, 60, 80]];
// let ogr2 = ["Saliha Temel", 2012, [80, 80, 90]];
// let ogr3 = ["Defne Küp", 2009, [60, 60, 70]];

// let ogrenciler = [ogr1, ogr2, ogr3];

// let kerimYas = new Date().getFullYear() - ogrenciler[0][1];
// let salihaYas = new Date().getFullYear() - ogrenciler[1][1];
// let defneYas = new Date().getFullYear() - ogrenciler[2][1];
// console.log(kerimYas, salihaYas, defneYas);

// let kerimOrt =
//   (ogrenciler[0][2][0] + ogrenciler[0][2][1] + ogrenciler[0][2][2]) / 3;
// let salihaOrt =
//   (ogrenciler[1][2][0] + ogrenciler[1][2][1] + ogrenciler[1][2][2]) / 3;
// let defneOrt =
//   (ogrenciler[2][2][0] + ogrenciler[2][2][1] + ogrenciler[2][2][2]) / 3;
// console.log(kerimOrt, salihaOrt, defneOrt);
// console.log(kerimOrt.toFixed(), salihaOrt.toFixed(), defneOrt.toFixed());

//#endregion

//#region SORU 3

// 3) 1- Aşağıdaki sipariş bilgilerini object içerisinde saklayınız.
//     2- Her siparişin ayrı ayrı kdv dahil toplam ödenen ücretini hesaplayınız. (kdv: %18)
//     3- Tüm siparişlerin kdv dahil toplam ödenen ücretini hesaplayınız.

//     sipariş id: 101
//     sipariş tarihi: 31.12.2022
//     ödeme şekli: kredi kartı
//     kargo adresi: Yahya kaptan mah. Kocaeli İzmit
//     satın alınan ürünler:
//         ürün id: 5
//         ürün başlığı: IPhone 13 Pro
//         ürün url: http://abc.com/iphone-13-pro
//         ürün fiyatı: 22000

//         ürün id: 6
//         ürün başlığı: IPhone 13 Pro Max
//         ürün url: http://abc.com/iphone-13-pro-max
//         ürün fiyatı: 25000

//     müşteri:
//         müşteri id: 12

//     satıcı:
//         firma id: 34
//         firma adı: Apple Türkiye

//     sipariş id: 102
//     sipariş tarihi: 30.12.2022
//     ödeme şekli: kredi kartı
//     kargo adresi: Yahya kaptan mah. Kocaeli İzmit
//     satın alınan ürünler:

//         ürün id: 6
//         ürün başlığı: IPhone 13 Pro Max
//         ürün url: http://abc.com/iphone-13-pro-max
//         ürün fiyatı: 25000

//     müşteri:
//         müşteri id: 12

//     satıcı:
//         firma id: 34
//         firma adı: Apple Türkiye


// let siparis1 = {
//   siparisId: "101",
//   siparisTarihi: "31.12.2022",
//   odemeSekli: "Kredi Kartı",
//   kargoAdresi: {
//     adresMah: "Yahya kaptan Mah.",
//     adresIlce: "İzmit",
//     adresIl: "Kocaeli",
//   },
//   urunler: [
//     {
//       urunId: "5",
//       urunAdi: "Iphone 13 Pro",
//       urunUrl: "http://abc.com/iphone-13-pro",
//       urunFiyat: 22000,
//     },
//     {
//       urunId: "6",
//       urunAdi: "Iphone 13 Pro Max",
//       urunUrl: "http://abc.com/iphone-13-pro-max",
//       urunFiyat: 25000,
//     },
//   ],
//   musteri: {
//     musteriId: "12",
//   },
//   satici: {
//     firmaId: "34",
//     firmaAdi: "Apple Türkiye",
//   },
// };


// let siparis2 = {
//   siparisId: "102",
//   siparisTarihi: "30.12.2022",
//   odemeSekli: "Kredi Kartı",
//   kargoAdresi: {
//     adresMah: "Yahya kaptan Mah.",
//     adresIlce: "İzmit",
//     adresIl: "Kocaeli",
//   },
//   urunler: [
//     {
//       urunId: "6",
//       urunAdi: "Iphone 13 Pro Max",
//       urunUrl: "http://abc.com/iphone-13-pro-max",
//       urunFiyat: 25000,
//     },
//   ],
//   musteri: {
//     musteriId: "12",
//   },
//   satici: {
//     firmaId: "34",
//     firmaAdi: "Apple Türkiye",
//   },
// };

// let siparisler = [siparis1, siparis2];

// let siparis1KDV =
//   siparis1.urunler[0].urunFiyat * 0.18 + siparis1.urunler[1].urunFiyat * 0.18;
// let siparis2KDV = siparis2.urunler[0].urunFiyat * 0.18;


// console.log(`Toplam KDV : ${siparis1KDV + siparis2KDV}`);

// let toplam =
//   siparis1.urunler[0].urunFiyat +
//   siparis1.urunler[1].urunFiyat +
//   siparis2.urunler[0].urunFiyat;

// console.log(`Toplam sipariş ücreti : ${toplam}`);

//#endregion

//#region SORU 4

//     4-          4. SORU 7 ALT SORUDAN OLUSUYOR

// let sayilar = [1, 5, 7, 15, 3, 25, 12, 24];

//     4.1- sayilar listesindeki her bir elemanın karesini yazdırınız.

// for(let i = 0 ; i < sayilar.length; i++){
//    console.log(sayilar[i]*sayilar[i]);
// }

//     4.2- sayilar listesindeki hangi sayılar 5' in katıdır?

// for (let i = 0; i < sayilar.length; i++) {
//     console.log(sayilar[i], sayilar[i] % 5 == 0);
// }

//     4.3- sayilar listesindeki çift sayıların toplamını bulunuz.

// // // // // // // // // 1. çözüm

// let toplam = 0;

// for (let i = 0; i < sayilar.length; i++) {
//   if (sayilar[i] % 2 == 0) {
//     toplam += sayilar[i];
//   }
// }
// console.log(toplam);

// // // // // // // // // 2. çözüm

// let toplam1 = 0;

// for (let i in sayilar) {
//   if (sayilar[i] % 2 == 0) {
//     toplam1 += sayilar[i];
//   }
// }

// console.log(toplam1);

//     4.4-

// let urunler = [
//   "iphone 12",
//   "samsung s22",
//   "iphone 13",
//   "samsung s23",
//   "samsung s20",
// ];

//     4- urunler listesindeki tüm ürünleri büyük harf ile yazdırınız.

// // // // // // // // 1. çözüm

// for(let i = 0 ; i < urunler.length; i++){
//     console.log(urunler[i].toUpperCase());
// }

// // // // // // // // 2. çözüm

// for(let urun of urunler){
//     console.log(urun.toUpperCase());
// }

//     4.5- urunler listesinde samsung geçen kaç ürün vardır?

// // // // // // // 1. çözüm

// let adet = 0 ;

// for(let i = 0 ; i < urunler.length; i++){
//     if(urunler[i].includes("samsung")){
//         adet++;
//     }
// }
// console.log(adet);

// // // // // // // 2. çözüm

// let adet1 = 0;

// for(let urun of urunler){
//     if(urun.includes("samsung")){
//         adet1++;
//     }
// }
// console.log(adet1);

//     4.6- ogrenciler listesindeki her öğrencinin not ortalaması ve başarı durumlarını yazdırınız.

//     4.7- tüm öğrencilerin not ortalaması kaçtır?

// // // // // // // // // // // // 1. çözüm 

// let ogrenciler = [
//   { ad: "yiğit", soyad: "bilgi", notlar: [60, 70, 60] },
//   { ad: "ada", soyad: "bilgi", notlar: [80, 70, 80] },
//   { ad: "çınar", soyad: "turan", notlar: [10, 20, 60] },
// ];

// for (let ogrenci of ogrenciler) {
//   let notToplam = 0;
//   let ortalama = 0;
//   let adet = 0;
//   for (let not of ogrenci.notlar) {
//     notToplam += not;
//     adet++;
//   }
//   ortalama = notToplam / adet;

//   console.log(
//     `${ogrenci.ad} ${ogrenci.soyad} isimli öğrencinin not ortalaması : ${ortalama}.`
//   );
//   if (ortalama >= 50) {
//     console.log("Başarılı.");
//   } else {
//     console.log("Başarısız.");
//   }
// }


// // // // // // // // // // // // 2. çözüm 


// let ogrenciler = [
//   { ad: "yiğit", soyad: "bilgi", notlar: [60, 70, 60] },
//   { ad: "ada", soyad: "bilgi", notlar: [80, 70, 80] },
//   { ad: "çınar", soyad: "turan", notlar: [10, 20, 60] },
// ];

// for (let i = 0; i < ogrenciler.length; i++) {
//   let notlar = ogrenciler[i].notlar;
//   let ortalama = 0;
//   let toplamNot = 0;

//   for (let m = 0; m < notlar.length; m++) {
//     toplamNot += notlar[m];
//   }

//   ortalama = (toplamNot / notlar.length).toFixed();
//   console.log(ogrenciler[i].ad + " " + ogrenciler[i].soyad + " " + ortalama);
// }

// let toplamNot = 0;
// let toplamOgrenci = 0;

// for (let i = 0; i < ogrenciler.length; i++) {
//   let notlar = ogrenciler[i].notlar;
//   for (let m = 0; m < notlar.length; m++) {
//     toplamNot += notlar[m];
//   }
//   toplamOgrenci += notlar.length;
// }

// let ortalama = (toplamNot / toplamOgrenci).toFixed();

// console.log("Notların Ortalaması: " + ortalama);


//     4.6- ogrenciler listesindeki her öğrencinin not ortalaması ve başarı durumlarını yazdırınız.

//     4.7- tüm öğrencilerin not ortalaması kaçtır?

// // // // // // // // // 2. çözüm hocaya sor yanyana yazdırma olayı 

// let toplam1 = 0 ;
// let toplam2 = 0 ;
// let toplam3 = 0 ;

// for (let i = 0; i < ogrenciler.length; i++) {

//     toplam1 += (ogrenciler[0].notlar[i])/3;
//     toplam2 += (ogrenciler[1].notlar[i])/3;
//     toplam3 += (ogrenciler[2].notlar[i])/3;
// }

// console.log(toplam1 , toplam2 , toplam3);

// let ortalamalar = [toplam1 , toplam2 , toplam3];

// for( let i =0; i< ortalamalar.length; i++){
//     if(ortalamalar[i]>=50) {
//         console.log(`${ortalamalar[i].toFixed()} "Başarılı."`);
//     }
//     else{
//       console.log(`${ortalamalar[i].toFixed()} "Başarısız."`);
//     }
// }

// console.log((toplam1 + toplam2 + toplam3)/3);

//#endregion

//#region SORU 5

// 5) Kendisine gönderilen kelimeyi belirtilen kez ekranda yazan fonksiyonu yapınız.

//   Örnek kullanım: kelimeYazdir("merhaba", 2);

// // // // // // // // 1. çözüm

// function kelimeYazdir(kelime,adet){
//         let sonuc = (`${kelime} `.repeat(adet));
//         console.log(sonuc);
// }

// kelimeYazdir("seko" , 2);

// // // // // // // // 2. çözüm

// function kelimeYazdir(kelime , adet){
//     for(let i = 0 ; i < adet ; i++){
//         console.log(kelime);
//     }
// }

// kelimeYazdir("Mücahit" , 4);

// // // // // // // // // 3. çözüm yarıda kalan

// // // // // // // // // function kelimeYazdir() {
// // // // // // //     let kelime = prompt("kelime yaz : " );
// // // // // // //     kelime = kelime.toString();
// // // // // // //     let adet = prompt("Adet Yaz : ");
// // // // // // //     adet = parseInt(adet);
// // // // // // //     let tekrar = kelime.repeat(adet);
// // // // // // //     console.log(`${tekrar}` );
// // // // // // // }

// // // // // // // console.log(kelimeYazdir());

//#endregion

//#region SORU 6

// 6) Dikdörtgenin alan ve çevresini hesaplayan fonksiyonu yazınız.

//   Örnek kullanım: let sonuc = alanCevreHesapla(7, 10);

// // // // // // // // // // // 1. çözüm

// function dikdortgenAlanCevre(kisaKenar , uzunKenar){
//     let alan = (kisaKenar + uzunKenar) * 2;
//     let cevre = kisaKenar * uzunKenar;
//     console.log(`Dikdörtgenin alanı : ${alan} \nDikdörtgenin çevresi : ${cevre}`);
// }

// dikdortgenAlanCevre(3 ,5);

// // // // // // // // // // // 2. çözüm

// function dikdortgenAlanCevre(kisaKenar , uzunKenar){
//     let alan = (kisaKenar + uzunKenar) * 2;
//     let cevre = kisaKenar * uzunKenar;
//     return (`Dikdörtgenin alanı : ${alan} \nDikdörtgenin çevresi : ${cevre}`);
// }

// let sonuc = dikdortgenAlanCevre(3 ,5);
// console.log(sonuc);

//#endregion

//#region 7. SORU

// 7) Yazı tura uygulamasını(uygulama çalıştığında sonuç olarak ya yazı ya da tura diyecek) fonksiyon kullanarak yapınız.

//   Örnek kullanım: yaziTuraAt();

// function yaziTuraAt() {
//     let random = Math.random();
//     if (random <= 0.5) {
//       console.log("Yazı");
//     } else {
//       console.log("Tura");
//     }
//       console.log(random);
//   }

//   yaziTuraAt();

//#endregion

//#region 8. SORU

// 8) Kendisine gönderilen bir sayının tam bölenlerini dizi şeklinde döndüren fonksiyonu yazınız.

//   Örnek kullanım: console.log(tamBolenler(10));    // 1,2, 5

// function tamBolenler(sayi) {
//   let sayilar = [];

//   for (let i = 1; i < sayi; i++) {
//     if (sayi % i == 0) {
//       sayilar.push(i);
//     }
//   }
//   return sayilar;
// }

// console.log(tamBolenler(10));

//#endregion

//#region 9. SORU

// 9) Değişken sayıda parametre alan carpim isminde bir fonksiyon tanımlayınız.

// function carpim() {
//   let sonuc = 0;

//   for (let i = 0; i < arguments.length ; i++) {
//     sonuc += arguments[i];
//     sonuc *= arguments[i];
//   }
//   return sonuc;
// }

// console.log(carpim(2,5,4,5,4));


//#endregion

//#region 10. SORU

// 10) Verilen bir metnin her sözcüğününün ilk harfleri büyük geri kalanları küçük hale dönüştürecek functionu hazırlayınız.

// let metin=prompt("bir metin giriniz:");
// let textUpdates=[];
// let i;
// function metinDuzenleme(){
// let textUpdate=metin.split(" ");
// for(let i=0;i<textUpdate.length;i++) {
// textupdates[i]=textUpdate[i][0].toLocaleUpperCase() + textUpdate[i].substr(1);
// }
// console.log(textUpdates)
// }
// metinDuzenleme();
// //#endregion
