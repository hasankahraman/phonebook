using System;
using System.Collections.Generic;
using System.Linq;

namespace phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PhoneNumber> numberList = new List<PhoneNumber>()
            {
                    new PhoneNumber{
                        FirstName = "Hasan",
                        LastName = "KAHRAMAN",
                        Number = "5534125943"
                    },
                    new PhoneNumber{
                        FirstName = "Arzu",
                        LastName = "KAHRAMAN",
                        Number = "5334055943"
                    },
                    new PhoneNumber{
                        FirstName = "Sema",
                        LastName = "KAHRAMAN",
                        Number = "5061237644"
                    },
                    new PhoneNumber{
                        FirstName = "Fatma",
                        LastName = "KAHRAMAN",
                        Number = "5437684392"
                    },
                    new PhoneNumber{
                        FirstName = "Mustafa",
                        LastName = "KAHRAMAN",
                        Number = "5437684378"
                    }
            };
            bool tekrar = true;
            while(tekrar)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)\n*******************************************\n(1) Yeni Numara Kaydetmek\n(2) Varolan Numarayı Silmek\n(3) Varolan Numarayı Güncelleme\n(4) Rehberi Listelemek\n(5) Rehberde Arama Yapmak");
                int input = Convert.ToInt32((Console.ReadLine()));


                switch (input)
                {
                case 1: //Yeni Kayıt Ek
                    PhoneNumber enteredRecord = new PhoneNumber();

                    Console.WriteLine("Lütfen isim giriniz             :");
                    enteredRecord.FirstName = Console.ReadLine();

                    Console.WriteLine("Lütfen soyisim giriniz          :");
                    enteredRecord.LastName = Console.ReadLine();

                    Console.WriteLine("Lütfen telefon numarası giriniz :");
                    enteredRecord.Number = Console.ReadLine();

                    numberList.Add(enteredRecord);
                    Console.WriteLine("Kayıt işlemi başarıyla gerçekleştirildi.\n**********************************************");
                    break;

                case 2: //Var Olan Kaydı Sil

                    Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                    string toDelete = Console.ReadLine();

                    var number = numberList.SingleOrDefault(x=> x.FirstName == toDelete || x.LastName == toDelete);
         
                    bool silmeDurumu = true;
                    while (silmeDurumu)
                    {
                        if(number is not null){ // Eğer aranan değerde kayıt var ise
                        
                        Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)", number.FirstName);
                        string result = Console.ReadLine();

                        if(result == "y"){ // evet ise
                            numberList.Remove(number);
                            Console.WriteLine("Kayıt silindi.");
                        }else if (result == "n"){ //hayır ise
                            Console.WriteLine("Kayıt silinmekten vazgeçildi.");
                        }
                        silmeDurumu = false;

                            
                        } else { // eğer aranan değerde kayıt bulunamadıysa
                            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\n* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için      : (2)");
                            silmeDurumu = Console.ReadLine() == "1" ? false : true;
                        }
                    }
    
                    break;
     
                case 3:
                
                bool guncellemeDurumu = true;
                while(guncellemeDurumu){
                    Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                    string toUpdate = Console.ReadLine();

                    var numberss = numberList.FirstOrDefault(x=> x.FirstName == toUpdate || x.LastName == toUpdate); 

                   

                    

                        if (numberss is null){ // Eğer veri yok ise
                        Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                        Console.WriteLine("* Güncellemeyi sonlandırmak için : (1)");
                        Console.WriteLine("* Yeniden denemek için      : (2)");

                        string result = Console.ReadLine();

                        if(result == "1"){
                            guncellemeDurumu = false;
                            Console.WriteLine("Güncelleme işlemi gerçekleştirilmeden sonlandırıldı.");
                        }else if (result == "2"){

                        }


                    }else { //eğer aranan kriterde kayıt bulundu ise

                    Console.WriteLine("Lütfen yeni isim giriniz             :");
                    numberss.FirstName = Console.ReadLine();

                    Console.WriteLine("Lütfen yeni soyisim giriniz          :");
                    numberss.LastName = Console.ReadLine();

                    Console.WriteLine("Lütfen yeni telefon numarası giriniz :");
                    numberss.Number = Console.ReadLine();

                    Console.WriteLine("Kayıt Başarılı Bir Şekilde Güncellendi.");
                    guncellemeDurumu = false;


                    }
                    }

                    break;

                case 4: //Rehberi Listeler
                    Console.WriteLine("Telefon Rehberi");
                    Console.WriteLine("**********************************************");
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        Console.WriteLine("İsim: {0}", numberList[i].FirstName);
                        Console.WriteLine("Soyisim: {0}", numberList[i].LastName);
                        Console.WriteLine("Telefon Numarası: {0}", numberList[i].Number);
                        Console.WriteLine("-");
                    }
                    break;

                case 5: //Rehberde Arama Yap
                    Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                    Console.WriteLine("**********************************************");
                    
                    Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
                    Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
                    string aramaTuru = Console.ReadLine();

                    Console.WriteLine("Arama yapmak istediğiniz metni yazınız: ");
                    string toSearch = Console.ReadLine();
                    var numbers = new List<PhoneNumber>();
                    
                    if(aramaTuru == "1"){
                        numbers = numberList.Where(x=> x.FirstName == toSearch || x.LastName == toSearch).ToList<PhoneNumber>();

                    }else if (aramaTuru == "2"){
                        numbers = numberList.Where(x=> x.Number == toSearch).ToList<PhoneNumber>();
                    }

                    if (numbers is null){
                        Console.WriteLine("Aradığınız kriterlerde kayıt bulunamadı. :(");
                    }else {
                        Console.WriteLine("Arama sonuçlarınız: ");
                        Console.WriteLine("**********************************************");

                        for (int i = 0; i < numbers.Count; i++)
                    {
                        Console.WriteLine("İsim: {0}", numbers[i].FirstName);
                        Console.WriteLine("Soyisim: {0}", numbers[i].LastName);
                        Console.WriteLine("Telefon Numarası: {0}", numbers[i].Number);
                        Console.WriteLine("-");
                    }
                    }



                    break;
            }
            }
            

        }
    }
}
