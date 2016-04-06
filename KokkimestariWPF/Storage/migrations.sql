BEGIN TRANSACTION;
CREATE TABLE Recipe (ID integer primary key not null, Name text not null, Instructions text not null, Ingredients text not null, Difficulty integer not null, Time integer not null, PicturePath text null);
INSERT INTO `Recipe` VALUES (1,'Mokkapalat','1 paketti 	tomusokeria 	
50 g 	voisulaa 	
5 rkl 	vahvaa kahvia 	
1 rkl 	kaakaojauhetta 	
2 tl 	vaniliinisokeria','5 dl 	vehnäjauhoja 	
4 	munaa 	
3 dl 	sokeria 	
2 dl 	maitoa 	
200 g 	voisulaa 	
3 rkl 	kaakaojauhetta 	
3 tl 	leivinjauhetta 	
2 tl 	vaniliinisokeria',0,25,'Images\mokkapalat.jpg');
INSERT INTO `Recipe` VALUES (2,'Mustikkapiirakka','sekoita sokeri ja pehmeä margariini keskenään. lisää muut aineet ja sekoita taikina tasaiseksi. levitä taikina voidellun ison piirakkavuuan pohjalle (minun piirakkavuuassa on 30cm halkaisija). kaada mustikat piirakkavuokaan ja levitä ne tasaisesti. Valmista murutaikina nyppimällä kaikki aineet murumaiseksi ja ripottele mustikoiden päälle. Paista piirakka 200 astessa uunissa n.30min.

Tarjoile vanilja jäätelön tai vanilja kastikkeen kanssa.
','pohja:
150 g 	margariinia 	
1,5 dl 	sokeria 	
1 	muna 	
3 dl 	vehnäjauhoja 	
1 tl 	vaniliinisokeria 	
1 tl 	leivinjauhetta 	
400 g 	mustikoita

murutaikina:
100 g 	margariinia 	
1 dl 	sokeria 	
2 dl 	vehnäjauhoja',0,45,'Images\mustikkapiirakka.jpg');
INSERT INTO `Recipe` VALUES (3,'Mutakakku','1. Sulata margariini
2. Vatkaa munat ja sokeri vaahdoksi
3. Lisää joukkoon kaakao ja vaniljasokeri
4. Sekoita joukkoon leivinjauhe ja vehnäjauhoseos
5. Lisää lopuksi jäähtynyt rasva
 
levitä taikina irtopohjavuokaan ja paista uunin keskiosassa

175¤ 15-25 min, niin että kakku jää sisältä hieman tahmeaksi

Koristele halutessasi tomusokerilla','2 	munaa 	
2 dl 	sokeria 	
4 rkl 	Kaakaota 	
1½ tl 	vaniljasokeria 	
1½ dl 	vehnäjauhoja 	
1 tl 	leivinjauhetta 	
155 g 	margariinia',0,25,'Images\mutakakku.jpg');
INSERT INTO `Recipe` VALUES (4,'Puolukkavispipuuro','Keitä puolukoita vedessä 10 min.
Siivilöi liemi, ja vispaa joukkoon jauhot.
Keitä 10 - 15 min.
Mausta sokerilla, anna jäähtyä ja vatkaa vaahdoksi.','1 l 	vettä 	
3,5 dl 	puolukoita 	
2 dl 	Farina Karkeaa riisijauhoa 	
0,6 dl 	sokeria',0,25,'Images\puolukkavispipuuro.jpg');
INSERT INTO `Recipe` VALUES (5,'Mansikkakakku','Vatkaa munat ja sokeri paksuksi vaahdoksi. Lisää keskenään sekoitetut kuivat aineet nostellen esim. nuolijalla.

Kaada seos voideltuun korppujauhotettuun vuokaan.

Paista 200 astetta 30min. Uunin alimmalla ritilätasolla.

Tee täyte: Vatkaa kerma vaahdoksi, soseuta mansikat ja sekoita kaikki sitten keskenään.

Jaa jäähtynyt kakku kolmeen osaan. Kostuta alin levy. Levitä täytettä.

Laita toinen levy päälle, kostuta ja täytä.

Laita kolmas levy päälle kostuta kevyesti.Laita kelmua päälle.

Pistä paino päälle ja noin 2 tunniksi jääkaappiin ( painoksi käy vaikka paksu leikkuulauta)

Vaahdota kerma reunoja varten lisää sokeri ja vaniljasokeri.

Päällystä kakun pinta kermavaahdolla ohuelti.

Pistä pinnalle mansikoita koristeeksi reilusti ja pursota reunat kermavaahdolla, tai tuputa kerma veitsellä kuten minä tein.','4 	munaa 	
1,5 dl 	sokeria 	
1 dl 	vehnäjauhoja 	
1 dl 	perunajauhoja 	
1 tl 	leivinjauhetta
 	
kostutus:
1 dl 	maitoa 	
1 1/2 tl 	vaniljasokeria 	

Täyte:
2 dl 	mansikoita 	
2 dl 	kuohukermaa 	
1 dl 	sokeria 	
2 tl 	vaniljasokeria 	

Reunoille:
4 dl 	kuohukermaa 	
2 rkl 	sokeria 	
1 tl 	vaniljasokeria 	
	mansikoita päälle koristeeksi',0,45,'Images\mansikkakakku.jpg');
INSERT INTO `Recipe` VALUES (6,'Suklaamuffinit','Sekoita kuivat aineet keskenään.
Hienonna suklaa muruiksi ja sekoita kuiviin aineksiin.
Lisää joukkoon munat, voi ja kerma.
Sekoita tasaiseksi.
Jaa muffinivuokiin lusikoita apuna käyttäen.
Paista muffinit 175 astetta 25-30min.
','3 1/2 dl 	vehnäjauhoja 	
2 tl 	leivinjauhetta 	
2 tl 	vaniljasokeria 	
1/2- 1 rkl 	kaakaojauhetta 	
1 1/2 dl 	sokeria 	
100 g 	suklaata pieniksi pilkottuna 	
2 	kananmunaa 	
1 dl 	sulatettua voita 	
1 dl 	Kermaa 	
	muffinsivuokia',0,25,'Images\suklaamuffinit.jpg');
INSERT INTO `Recipe` VALUES (7,'Pizza Denniksen tapaan',' Tämä on Turussa pitkään vaikuttaneen (vuodesta 1975) pizzaguru, Dennis Rafkinin ohje, mottona: Hyvän pizzan salaisuus on pohjataikina ja erittäin tulinen uuni. Nyttemmin Dennis pizerioita on Turun lisäksi ainakin Helsingissä ja Tampereella...

Sekoita aineet ja vaivaa taikina tasaiseksi. Anna taikinan huilata tunnin verran (tämä on tärkeää). Kaulitse ohuiksi pohjiksi, pakasta ylimääräinen taikina, annospaloina. Pohjalle levitetään kauttaaltaan, ihan reunoille saakka, tomaattimurska, johon on sekoitettu hiukan suolaa, oreganoa, pippuria ja valkosipulijauhetta. Seuraavaksi tulee juusto ja sitten maltillisesti täytteitä oman maun mukaan. Pohjalta täytteen läpi kuohuva juusto ottaa itseensä täytteistä makua. Uuni kuumennetaan 300 asteeseen (pizzeriassa uunin lämpötila on 400). Paistetaan alatasolla n. 5 min. Hyvä pizza ei saa olla ahdettu kukkuroilleen juustoa ja täytettä sanoo Dennis ! Nyt ei tehdä piirakkaa.

Täyte-esimerkki, BECKHAM SPECIAL:

kinkkua, tuoretta tomaattia, tuoretta basilikaa.

Täyte-esimerkki , "Kimi": Tomaattia, juustoa, salamia, jauhelihaa, maustekurkkua, herkkusieniä, raakaa sipulia.','1 l 	raikasta vettä 	
0,2 dl 	sokeria 	
0,3 dl 	suolaa 	
25 g 	hiivaa 	
1 dl 	maitoa 	
1 dl 	oliiviöljyä 	
2,5 kg 	puolikarkeita vehnäjauhoja (noin)',0,50,'Images\pizza.jpg');
INSERT INTO `Recipe` VALUES (8,'Broilerigratiini','Paista pannulla broilerinsuikaleet. Mausta. Laita kaalit ja broilerinsuikaleet vuokaan. Sekoita kerma ja greme ja kaada vuokaan kaalijen ja broilerin päälle. Tarkista maku. Juustoraastetta päälle ja uuniin 200 astetta noin 40 min.','300 g 	kukkakaalia 	
300 g 	parsakaalia 	
400 g 	marinoimattomia broilerinsuikaleita 	
1 prk 	greme Bonjour cuissine sipulinmaku 	
2 dl 	kuohukermaa 	
	voita 	
	suolaa 	
	currya 	
	mustapippuria 	
1-2 dl 	juustoraastetta',0,55,'Images\broilerigratiini.jpg');
INSERT INTO `Recipe` VALUES (9,'Lasagne','Jauhelihakastike:

    Ruskista jauhelihat pilkottujen sipuleiden ja valkosipuleiden kanssa öljyssä tai voissa
    Lisää tomaattimurska ja mausteet
    Hauduta 15 minuuttia

Juustokastike

    Sulata rasva ja sekoita lisää siihen jauhot
    Lisää hiljalleen maito kokoajan sekoittaen (ei kannata käyttää vispilää, sillä sen puhdistaminen on vaikeaa)
    Kun maito alkaa kiehua, lisää mausteet (mustapippuri, suola ja muskotti) ja juustoraasteesta 2/3 maitoon

Voitele vuoka ja kaada pohjalle juustokastiketta ohut kerros. Lisää lasagnelevyjä (3-4 kpl) kunnes pohja on peittynyt. Lisää noin 1/3 jauhelihasta ja kaada päälle 1/3 juustokastikkeesta. Jatka, kunnes kaikki aineet loppuvat. Lopuksi kruunaa komeus vielä lasagnelevykerroksella ja sirottele loput juustoraasteesta päälle.

Paista noin 200 asteessa 30-40 minuuttia tai kunnes pinta on kauniin ruskea.

Lasagnen tekeminen yksin vaatii täydellistä keskittymistä, varsinkin jos teet juustokastikkeen samalla kun haudutat jauhelihaa.',' lasagnelevyjä 	

Jauhelihakastike:
400 g 	jauhelihaa 	
3 kynttä 	valkosipulia 	
3 kpl 	sipuleja 	
2 tlk 	tomaattimurskaa 	
3 rkl 	tomaattisosetta 	
2 kpl 	lihaliemikuutioita 	
	mustapippuria 	
	Oreganoa 	

Juustokastike:
5 rkl 	voita 	
1 dl 	vehnäjauhoja 	
9 dl 	maitoa 	
200 g 	juustoraastetta 	
	muskottia 	
	suolaa',0,60,'Images\lasagne.jpg');
INSERT INTO `Recipe` VALUES (10,'Kasvisleikkeet salaatilla','Sulata kasvisleikkeet ja paista paistinpannulla voissa.

Pilko tomaatit ja avocadot. Sekoita kulhossa maissin ja papujen kanssa. Paahda pinjansiemenet ja ripottele salaatin päälle. Tarjoile salaatti kasvisleikkeiden kera.
','1 pkt 	Hälsans Kök kasvisleikkeitä 	
2–3 	herkkusientä 	
1 	pieni purkki kidneypapuja 	
3 	tomaattia 	
1 	purkki maissia 	
2 	avocadoa 	
1 	pussi rucolaa 	
	Pinjansiemeniä',0,25,'Images\kasvisleikkeet.jpg');
INSERT INTO `Recipe` VALUES (11,'Lohisalaatti','

Revi salaatinlehdet tarjoiluastiaan.

Kuutioi kurkku ja paprika, leikkaa sipuli renkaiksi.

Puolita tomaatit.

Leikkaa kananmunat lohkoiksi.

Pistä kaikki kulhoon jätä kananmunat koristeluun.

Lisää lohi ja sekoita ihan vähän ,että ovat sekaisin.

Koristele kananmunilla.

P.S Jos haluat kastikkeen, linkki on ohjeen lopussa nopsaa ja oivaan kermaviilikastikkeeseen,joka on tehtävä pariakin tuntia ennen ateriaa, että ennättää maustua.

Kastike sopii myös muun kalaruuan kera.
','1 	jäävuorisalaatti kerä 	
4-5 	luumutomaattia 	
1/2 	punaista paprikaa 	
1 	punasipuli 	
1/2 	kotimaista tuorekurkkua 	
3-4 	keitettyä kananmunaa 	
300 g 	lämminsavulohta paloiksi leikattuna',0,15,'Images\lohisalaatti.jpg');
INSERT INTO `Recipe` VALUES (12,'Mehevä tonnikalasalaatti ','Valuta tonnikalasta ja raejuustosta liemi pois siivilässä.

Pese vihannekset ja rypäleet hyvin, valuta vesi pois.

Revi salaatti.

Pilko tomaatit ja kurkku ja puolita rypäleet.

Leikkaa sipuli ohuiksi renkaiksi.

Yhdistä kaikki ainekset ja lisää maun mukaan mausteita.

Nauti tuoreen patongin ja viinin kera hyvässä seurassa :)
','1 	jääsalaatti (koko puska) 	
2-3 kpl 	tomaattia 	
1/2 	kurkku 	
1 prk 	tonnikalaa (fileinä vedessä) 	
1 prk 	raejuustoa 	
1 1/2 dl 	viinirypäleitä, tummia kivettömiä 	
1 	punasipuli 	
ripaus 	suolaa 	
	sitruunapippuria',0,20,'Images\tonnikalasalaatti.jpg');
INSERT INTO `Recipe` VALUES (13,'Broilerisalaatti','Ruskista broilerisuikaleet pannulla ja anna jäähtyä.

Valmista salaattikastike. Murenna aurajuusto kermaviilin sekaan ja mausta suolalla (aurajuustossakin on suolaa) ja mustapippurilla.

Pilko paprika, päärynä ja kirsikkatomaatit ja lisää ne revittyjen salaatinlehtien päälle. Lisää broilerisuikaleet ja tarjoa aurajuustokastikkeen kanssa.','300 g 	broilerin fileesuikaleita (marinoituja) 	
1 ruukku 	Jääsalaattia 	
1 	paprika 	
1 	päärynä 	
10 	kirsikkatomaattia 	
Kastike:
½ prk 	kermaviiliä 	
50 g 	aurajuustoa 	
½ 	valkosipulin kynsi 	
	suolaa 	
	mustapippuria',0,15,'Images\broilerisalaatti.jpg');
INSERT INTO `Recipe` VALUES (14,' Helppo perunasalaatti ','Leikkaa kylmät ja kuoritut perunat kuutioiksi. Silppua sipuli ja kuutioi omenat ja suolakurkut.

Sekoita makusi mukaan kermaviiliin mausteet ja sekoita kastike salaattiin.

Anna maustua viileässä muutama tunti.

Tarjoile esim. nakkikääröjen kanssa. 
','8-10 	keitettyä kiinteää perunaa 	
2 	sipulia 	
3 	suolakurkkua 	
1-2 	omenaa 	
3-4 dl 	kermaviiliä 	
	suolaa 	
	sokeria 	
	sinappia 	
	valkopippuria',0,15,'Images\perunasalaatti.jpg');
INSERT INTO `Recipe` VALUES (15,'Suppilovahverokeitto','
    kuullota sipulisilppu kattilassa kuumennetussa öljyssä
    lisää sienet ja kypsennä niitä hetken aikaa
    sekoita jauhot joukkoon
    lisää vesi ja murenna mukaan liemikuutiot
    keitä hiljalleen 10 min
    lisää kerma ja sulatejuusto
    keitä edelleen 5 min
    mausta keitto kypsymisen aikana
','1-2 	sipulia hienonnettuna 	
1 rkl 	öljyä 	
1 l 	suppilovahveroita tai (4 dl pakastettuja) 	
2 rkl 	vehnäjauhoja 	
7 dl 	vettä + 2 kasvisliemikuutiota 	
2 dl 	Kermaa 	
100 g 	sulatejuustoa tai tuorejuustoa 	
	yrtti-pippuriseosta 	
	yrttisuolaa 	
	tuoretta kirveliä tai persiljaa, silputtuna',0,15,'Images\suppilovahverokeitto.jpg');
INSERT INTO `Recipe` VALUES (16,'Samettinen porkkanakeitto','LISÄÄ KIEHUVAAN LIEMEEN KUORITUT PORKKANAT, SIPULI JA SELLERI PIENINÄ KUUTIOINA. KEITÄ KYPSÄKSI JA LISÄÄ MAUSTEET JA JUUSTO. SEKOITA KUNNES JUUSTO SULAA. SOSEUTA PEHMEÄKSI. KORISTELE PERSILJALLA.','1 LITRA 	kasvislientä 	
500 G 	porkkanoita 	
1 	Sipuli 	
1 PIENI PALA 	juuriselleriä 	
1/2 RASIAA 	KEVYT AAMUPALA JUUSTOA 	
	meiramia 	
	mustapippuria 	
	persiljaa',0,25,'Images\porkkanakeitto.jpg');
INSERT INTO `Recipe` VALUES (17,'kylmäsavulohirullat','Levitä kylmäsavulohet "laatoiksi". sekoita täytteen ainekset keskenään ( maista täytettä jotta tiedät paljon haluat laittaa mausteita), ja levitä täyte laattojen päälle. tämän jälkeen käännä ne rulliksi, ja pistä kelmun sisässä pakkaseen. Anna kohmettua pakkasessa ( voi antaa olla niin kauan kuin itse haluaa, esim. 1 tunti ja sulamaan hiukan ennen ruokailua ettei ole ihan jäässä) ja pilko ns. "kääretorttuviipaleiksi" :) maukas lisäke aterialla.','1-2 pkt 	kylmäsavulohta 	
1 rasia 	ruohosipulituorejuustoa 	
1 rasia 	creme fraichea 	
2 kynttä 	valkosipulia ( murskataan ) 	
	Tilliä oman maun mukaan 	
	vähän sinappia 	
	paprikajauhetta oman maun mukaan 	
	sitruunapippuria oman maun mukaan',0,15,'Images\lohirullat.jpg');
CREATE TABLE FavouriteList_Recipe (ID integer primary key not null, FavouriteList_id integer not null, Recipe_id integer not null, unique(FavouriteList_id, Recipe_id), foreign key (FavouriteList_id) references FavouriteList(ID) on delete cascade, foreign key (Recipe_id) references Recipe(ID) on delete cascade);
INSERT INTO `FavouriteList_Recipe` VALUES (1,1,15);
INSERT INTO `FavouriteList_Recipe` VALUES (2,1,10);
INSERT INTO `FavouriteList_Recipe` VALUES (3,1,4);
INSERT INTO `FavouriteList_Recipe` VALUES (4,3,1);
INSERT INTO `FavouriteList_Recipe` VALUES (5,3,2);
INSERT INTO `FavouriteList_Recipe` VALUES (6,3,3);
INSERT INTO `FavouriteList_Recipe` VALUES (7,3,6);
INSERT INTO `FavouriteList_Recipe` VALUES (8,3,5);
INSERT INTO `FavouriteList_Recipe` VALUES (9,2,11);
INSERT INTO `FavouriteList_Recipe` VALUES (10,2,14);
INSERT INTO `FavouriteList_Recipe` VALUES (11,2,13);
INSERT INTO `FavouriteList_Recipe` VALUES (12,2,12);
CREATE TABLE FavouriteList(ID integer primary key not null, Name text not null, Description text null);
INSERT INTO `FavouriteList` VALUES (1,'Kolmen ruokalajin menú','Ruokalista illalliselle');
INSERT INTO `FavouriteList` VALUES (2,'Salaatit','Kevyttä kesäpäivään!');
INSERT INTO `FavouriteList` VALUES (3,'Jälkiruoat','Herkkusuun menú');
CREATE TABLE Difficulty (ID integer primary key not null, Name text not null);
INSERT INTO `Difficulty` VALUES (1,'Helppo');
INSERT INTO `Difficulty` VALUES (2,'Keskivaikea');
INSERT INTO `Difficulty` VALUES (3,'Vaikea');
INSERT INTO `Difficulty` VALUES (4,'Tosi vaikea');
COMMIT;
