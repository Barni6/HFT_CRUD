# Rétegzett CRUD Alkalmazás

Ez a projekt a **Haladó Fejlesztési Technikák** kurzus keretében készült, és egy rétegzett architektúrájú CRUD alkalmazást valósít meg. Az alkalmazás egy saját adatbázist használ, amelyet az Entity Framework Core támogat, és .NET 5.0 verzióban készült.

## Funkciók

### Alapvető funkciók
- **CRUD műveletek**:
  - Az API támogatja a Create, Read, Update és Delete műveleteket.
  - Az alapvető HTTP műveletekhez igazítva: 
    - `GET`: Adatok lekérdezése.
    - `POST`: Új adatok létrehozása.
    - `PUT`: Létező adatok módosítása.
    - `DELETE`: Adatok törlése.
- **Non-CRUD műveletek**:
  - Többtáblás lekérdezések, például összetett kapcsolati adatokat használó lekérdezések.

### Architektúra
- **Rétegzett szerkezet**:
  - **Models**: Az adatbázis táblákat reprezentáló osztályok, amelyek idegen kulcsokat és navigációs property-ket tartalmaznak.
  - **Repository**: Az adatbázis műveletekért felelős réteg.
  - **Logic**: Az üzleti logikát tartalmazó réteg, amely a CRUD és non-CRUD műveleteket implementálja.
  - **Endpoint**: Az API-kat biztosító réteg.
  - **Test**: Unit tesztelési projekt NUnit és Moq használatával.
- **Dependency Injection (DI)**: Az egyes rétegek között DI biztosítja a függőségek kezelhetőségét.
- **InMemoryDb**: Teszteléshez használt adatbázis, amely az alkalmazás indulásakor inicializálódik.

### Tesztelés
- **Egységtesztek**:
  - Több mint 10 teszt, amelyek a Logic réteg funkcióit, például hibakezelést és non-CRUD műveleteket ellenőriznek.
  - NUnit és Moq könyvtárak használata.

### API Kommunikáció
- Az API JSON üzenetek segítségével kommunikál a konzolos alkalmazással.

## Telepítés és Használat

1. **Követelmények telepítése**:
   - .NET 5.0 SDK
   - Visual Studio (ajánlott a verziókövetéshez és a projekt kezeléséhez).

2. **Projekt letöltése**:
   - Klónozd a repót a GitHub-ról:
     ```bash
     git clone https://github.com/Barni6/HFT_CRUD.git
     ```

3. **Adatbázis inicializálása**:
   - Az alkalmazás futtatásakor az InMemoryDb automatikusan inicializálódik mintaadatokkal.

4. **Alkalmazás futtatása**:
   - Indítsd el az alkalmazást Visual Studio-ban:
     - Állítsd be a **Backend** és **Frontend** projektek párhuzamos indítását.
   - Használj egy API tesztelési eszközt (pl. Postman) az API funkciók teszteléséhez.

## Technológiák

### Nyelv
- **C#**

### Keretrendszer
- **.NET 5.0**

### Könyvtárak és eszközök
- **Entity Framework Core**: Adatbázis műveletekhez.
- **NUnit**: Egységteszteléshez.
- **Moq**: Tesztelési mock objektumokhoz.

