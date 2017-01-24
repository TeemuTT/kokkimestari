# Kokkimestari
Kokkimestari on sovellus reseptien tallentamiseen ja selailuun.

# Asennus
Ohjelma on ladattavissa .zip-pakettina osoitteesta http://student.labranet.jamk.fi/~H8705/IIO11300/kokkimestari.zip. Pura paketti ja suorita sen jälkeen setup.exe. Ohjelma käynnistyy automaattisesti asennuksen jälkeen.
# Järjestelmävaatimukset
Sovellus toimii windows käyttöjärjestelmällä. Sovellus vaatii toimiakseen .NET frameworkin version 4.5.2.

# Toiminnallisuus
Kaikki suunniteltu toiminnallisuus toteutettiin. Näitä ovat...
* Reseptien luonti, muokkaus ja poisto
* Menújen luonti, muokkaus ja poisto
* Reseptin tulostus
* Reseptien hakeminen nimellä

Tietokannasta karsittiin erilliset ainesosat, sillä niillä ei koettu olevan tarpeeksi lisäarvoa. Ainekset kirjoitetaan tekstinä reseptin tietoihin. Erillisinä olioina aineksien tulostusta voisi hallita paremmin ja yhtenäistää, mutta nyt käyttäjällä on täysi vapaus muotoilla aineslista haluamallaan tavalla.

# Käyttöliittymä
Käyttöliittymässä hyödynnettiin [mahapps.metro-kirjastoa](http://mahapps.com/), jolla saatiin käyttöliittymä windowsin metro-tyyliseksi.
![Kuvakaappaus1](http://student.labranet.jamk.fi/~H8705/IIO11300/sc1.png)
![Kuvakaappaus2](http://student.labranet.jamk.fi/~H8705/IIO11300/sc2.png)
![Kuvakaappaus3](http://student.labranet.jamk.fi/~H8705/IIO11300/sc3.png)

# Tietovarastot ja tiedostot
Sovellus käyttää tietokantana paikallista SQLite-tietokantaa. Ohjelma luo tietokannan käynnistyessään automaattisesti jos sitä ei ole olemassa. Tietokanta sisältää luonnin jälkeen joitakin reseptejä jo valmiiksi. Luontilauseet löytyvät [täältä](https://github.com/TeemuTT/kokkimestari/blob/master/KokkimestariWPF/Storage/migrations.sql).

![db](http://student.labranet.jamk.fi/~H8705/IIO11300/db.png)

Koska reseptien kuvat tallennetaan paikallisesti, ohjelman mukana on kuvat esimerkkiresepteille.

# Jatkokehitys
Reseptin tulostuksen yhteydessä voisi olla esikatselumahdollisuus. Reseptin tulostuksen asettelu on jokseenkin pelkistetty. Myös reseptin kuvan voisi tulostaa, tällä hetkellä tulostuu vain teksti.

Sopivan API:n löytyessä voitaisiin toteuttaa mahdollisuus selata ja tallentaa reseptejä verkosta.

# Työmäärä
Aikaa sovelluksen toteuttamiseen kului yhteensä noin 35h. Aikaa kului karkeasti lajiteltuna seuraavanlaisesti:

| Alue          | Aika    |
| --------------|---------|
| Suunnitelma   | 2h      |
| Käyttöliittymä| 14h     |
| Tietokanta    | 8h      |
| Logiikka      | 8h      |
| Dokumentointi | 2h      |



# Loppukaneetit
Kaiken kaikkiaan projektin tekeminen eteni mallikkaasti. Suunniteltu toiminnallisuus toteutettiin. Suuria vaikeuksia ei ilmennyt. Kirjastojen (SQLite, mahApps.metro) lisäys nuget-pm:ää käyttäen oli vaivatonta ja käyttö onnistui kirjastojen dokumentaatioiden avulla helposti.

Sovelluksesta tuli helppokäyttöinen ja hyvin toimiva. Tietokanta ja luokkarakenne eivät ole mahdottoman laajoja, mutta kuitenkin tarkoitukseen hyvin toimivia. Ehdotan työstä 25/30 pistettä.
