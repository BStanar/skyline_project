# skyline_project

Generalna ideja kako bi program mogao izgledati 
Bolnica je sastavljena od vise odjlea. Ti odjeli mogu da budu specijalisticki, prijem//porodicna medicina ili hitna pomoc. Svaki odjel ima specificne zadatke. 

Prijem moze da ima jednu instancu, jer nema smisla da postoji vise prijema.
Prijem ima glavnog doktora koji vodi odjel
Glavni doktor na prijemu pregledava pacijenta, redom kako su poredani u listi. Na kraju pregleda izdaje recept ili uputnicu.
Ako izda recept za lijekove pacijent ide kuci i smatra se izljecenim.
Ako izda uputnicu pacijent ide na odgovarajuci specijalisticki odjel, kosi se odreduje sa simptomima.
Prijem ima cekaonicu koja je ustvari queue pacijenata koji su na prijemu. Pregled pacijenata pocinje sa indeksom 0, first in first out
Nakon sto je ostalo 0 pacijenata kraj smjene i vlaca se na login screen 


Specijalisticki odjel, je za lijecenje 1 ili vise simptoma, Pacijent stize na lijecenje na specijalisticki odjel.
Ako pacijent ima 1 simptom radi se pregled i glavni doktor izdaje odpusno pismo, ako ima vise simptoma pacijent ide na lezanje na odjelu.
Svaki dojel ima max broj kreveta ~10, ako je popunjeno /*treba nesto uraditit*/ Pogledati koje jos simptome ima i mogu li se lijeciti na drugom odjelu, ako mogu prebacit ga, ako ni tu nema mjesto poslati ga na kraj prijema 
Svaki dan doktor/glavni doktor radi vizitu, za svaku vizitu ima 75% sanse da se ukloni jedan od simptoma na pacijentu.
Nakon sto se ukone svi simptomi glavni doktor izdaje odpusno pismo ili uputnicu za iduci specijalisticki odjel.
Ako izda odpusno pismo pacijent se smatra zdravim i ide kuci
Ako se izda uputnica za specijalisticki odjel pacijent se prebacuje na drugi odjel.

Nakon sto je ostalo 0 pacijenata kraj smjene i vlaca se na login screen

Bolnica 
****************************************
Naziv
adresu
Zgrada
broj specijalistickih klinika
Broj zaposlenih
ListaOdjela[]
ListaZaposlenih[]
****************************************

Odjel 
****************************************
tip [Prijem, Seccijalisticki]
Naziv
Adresa
Zgrada
Broj osoblja
Doktor[] 	//minimalno jedan doktor po odjelu
Sestre[]
****************************************

Specijalisticki odjel
****************************************
Specijalizaciju
Lista simptoma koje moze lijeciti
Br kreveta
Br zauzetih kreveta
Pacijenti koji su na lezanju []
****************************************

Doktor
****************************************
id										*
Ime 									*
Prezime									*
Spol									*
Telefon									*
Pocetak rada							*
Pozicija								*
Username								*
Password								*
Specijalizacija							*
Glavni doktor							*
****************************************



Pacijent
****************************************
id										*
Ime 									*
Prezime 								*
Telefon									*
zdravstveno osiguran					*
Simptomi[]								*
****************************************



Ako je username i passwrod admin admin
Dolazi do mogucnosti dodavanja novih zaposlenih, novih odjela, ili novih pacijenata

Ako se loguje doktor koji je postavljen u prijemu on odlucuje sta ce biti sa pacijentima, prikazuju mu se jedan po jedan. NA prozoru vidi :

Ime:  Boris  Prezime: Stanar Godina: 27 Spol: M
Simpotomi:	simptom 1
			simpotm 2
			simpotm 3....
			
*********************************************************
1. Izdati recept
2. Izdati uputnicu za specijalisticki odjel
***********************************************************
1. Izdati recept

Opis :sdasdasdasdasdasdasdasdasd
sadasdasdasdasdasdasdasdadasdasd
asdasdasdasdasdasdasdasdasdasdasd
***********************************************************
2. Izdati uputnicu (Izdaje se uputnica i pacijent se salje na specijalisticki odjel, doktoru se nista ne prikazuje pacijen)
*******************************************************************

Nakon toga se opet prikazuje pocetni zigled sa novim pacijentom

Ako se loguje doktor koji je postavljen u specijalistickom odjeli on odlucuje koje pacijente ce obici . NA prozoru vidi :
*************************
1.Lista cekanja
2.Vizita 	ako nema pacijenata na odjelu nema vizite
*******************************************************************
Izabere 1 prikaze se Lista cekanja, 
***********************************************
Ime:  Boris  Prezime: Stanar Godina: 27 Spol: M
Simpotomi:	simptom 1
			simpotm 2
			simpotm 3....
			ista funkcionalnost kao na prijemu
*********************************************************
1. Izdati recept
2. Zadrzati na odjelu
*****************************************************
Ako izabere 2. prikazuje sve pacijente koji leze na odjelu, bira kojeg pacijenta ce obici
1. Pacijent:
	Ime:  Boris  Prezime: Stanar Godina: 27 Spol: M 
2. Pacijent:
	Ime:  Boris  Prezime: Stanar Godina: 27 Spol: M  
3. Pacijent:
	Ime:  Boris  Prezime: Stanar Godina: 27 Spol: M  
4. Pacijent:
	Ime:  Boris  Prezime: Stanar Godina: 27 Spol: M 
*******************************************************************
	
Ako jedan pacijent ozdravi
*****************************************************
Ako izabere 2. prikazuje sve pacijente koji leze na odjelu, bira kojeg pacijenta ce obici
1. [Zdravi pacijent ceka odpust ]Pacijent:
	Ime:  Boris  Prezime: Stanar Godina: 27 Spol: M 
2. Pacijent:
	Ime:  Boris  Prezime: Stanar Godina: 27 Spol: M  
3. Pacijent:
	Ime:  Boris  Prezime: Stanar Godina: 27 Spol: M  
4. Pacijent:
	Ime:  Boris  Prezime: Stanar Godina: 27 Spol: M 
*******************************************************************
Ako izabere pacijenta koji je sprenab za odpust pritisne 1, otvara se novi pogled
*******************************************************************
Izdavanje odpusnog pisma

Opis :sdasdasdasdasdasdasdasdasd
sadasdasdasdasdasdasdasdadasdasd
asdasdasdasdasdasdasdasdasdasdasd
******************************************************************
Nakon toga se opet prikazuje pocetni zigled sa novim pacijentom

/*Dodati funkcionalnost za prebacivanje na druge odjele i prepoznavanje da se neki simptomi ne mogu izlijeciti na ovom odjelu i da se treba prebaciti na iduci odjel prije pustanja kuci

