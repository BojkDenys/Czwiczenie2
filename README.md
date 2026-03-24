## Ćwiczenie 2 – System wypożyczalni sprzętu
Konsolowa aplikacja w C# do zarządzania uczelnianą wypożyczalnią sprzętu.  
Studenci i pracownicy mogą wypożyczać laptopy, projektory i kamery.  
System pilnuje terminów zwrotu i nalicza kary za opóźnienia.

## Struktura projektu
Projekt podzielony jest na cztery warstwy: enumy, modele domenowe, serwisy z logiką biznesową oraz punkt wejścia aplikacji.

Enums/
-RentStatus.cs – status sprzętu: wolny, wypożyczony, niedostępny

Models/
-Electronic.cs – klasa bazowa dla całego sprzętu
-Laptop.cs – laptop (procesor, RAM)
-Camera.cs – kamera (megapiksele, stabilizator)
-Projector.cs – projektor (lumeny, rozdzielczość)
-User.cs – klasa bazowa użytkownika
-Student.cs – student (numer indeksu)
-Employee.cs – pracownik (wydział, stanowisko)
-Rent.cs – rekord wypożyczenia (kto, co, kiedy, kara)

Service/
-ElectronicService.cs – dodawanie i wyszukiwanie sprzętu
-UserService.cs – dodawanie i wyszukiwanie użytkowników
-RentService.cs – wypożyczanie, zwrot, sprawdzanie limitów
-StatisticService.cs – raporty i statystyki

Program.cs – scenariusz demonstracyjny, zero logiki biznesowej

## Podział odpowiedzialności
Każdy serwis robi jedną konkretną rzecz i nie wchodzi w kompetencje pozostałych:

-ElectronicService – wie tylko o sprzęcie: dodaj, znajdź, zmień status
-UserService – wie tylko o użytkownikach: dodaj, znajdź
-RentService – obsługuje wypożyczenia: sprawdź limit, wypożycz, przyjmij zwrot, policz karę
-StatisticService – tylko odczytuje dane i wyświetla raporty, niczego nie modyfikuje
-Program.cs - tylko uruchamia scenariusz, żadnej logiki


## Kohezja
Każda klasa skupia się na jednym temacie.  
Na przykład `Rent.cs` przechowuje wyłącznie dane o jednym wypożyczeniu – kto, co, kiedy wziął i kiedy zwrócił.  
Logika sprawdzania limitów i naliczania kar należy do RentService, nie do samego `Rent`.  
Modele (Laptop, Camera, Projector) zawierają tylko pola charakterystyczne dla danego typu sprzętu.


## Niski coupling
Serwisy nie znają się nawzajem bezpośrednio.  
RentService dostaje obiekty User i Electronic z zewnątrz – nie tworzy ich sam i nie odwołuje się do UserService ani ElectronicService wewnętrznie.  
Dzięki temu każdy serwis można modyfikować niezależnie od pozostałych.

## Reguły biznesowe
Maks. wypożyczeń dla studenta 2 
Maks. wypożyczeń dla pracownika 5 
Kara za dzień opóźnienia 5 PLN 
