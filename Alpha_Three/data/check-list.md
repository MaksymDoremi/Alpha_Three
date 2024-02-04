### Check list
- ✅ Dokumentace obsahuje nazev projektu, jmeno autora, jeho kontaktnı udaje, datum vypracovanı, nazev skoly a
informaci ze se jedna o skolnı projekt.
- ✅ Dokumentace obsahuje nebo odkazuje na specifikaci pozadavku uzivatele na praci s aplikacı nebo UML Use Case
diagramy, ktere to popisujı.
- ✅ Dokumentace databaze obsahuje popis architektury aplikace pomocı navrhovych vzoru, nebo UML stukturalnıch
diagramu, naprıklad Class digramy, Deployment diagramy apod.
- ✅ Dokumentace databaze obsahuje popis pouzıvanı a chodu aplikace pomocı UML behavioralnıch diagramu, naprıklad
State diagramy, Activity diagramy apod.
- ✅ Dokumentace obsahuje E-R model databaze, ze ktereho jsou patrne nazvy tabulek, atributu a jejich datove typy a
dalsı konfiguracne volby, pokud aplikace databazi pouzıva.
- ✅ Dokumentace obsahuje schema importovanych a exportovanych souboru, pokud aplikace databazi export a import
pouzıva, vcetne povinnych a nepovinnych polozek.
- ✅ Dokumentace obsahuje informace jak se program konfiguruje a jake konfiguracnı volby jsou prıpustne a co delajı.
- ✅ Dokumentace obsahuje popus instalace a spustenı aplikace, prıpadne odkazuje na soubor README.txt, kde je to
popsano.
- ✅ Dokumentace obsahuje popis vsech chybovych stavu, ktere mohou v aplikaci nastat a prıpadne i kody chyb a popis
postupu jejich resenı.
- ✅ Dokumentace vycet knihoven tretıch stran, ktere program vyuzıva.
- ✅ Dokumentace obsahuje zaverecne resume projektu.
- ✅ Dokumentace je zpracovana jedno souboru s prıponou .pdf nebo .md, prıpadne jako HTML stranka se vstupnım
souborem index.html.

Export programu a zdrojovych kodu
Pro kontrolu pri odevzdanı a exportu zdrojovych kodu, vcetne dalsıch souboru potrebnych pro beh programu pouzijte
nıze uvedeny seznam. Predevsım dbejte na dobre pojmenovanı slozek a souboru.
- ✅ Export zdrojovych kodu obsahuje rozummnou strukturu slozek a modulu (src pro kod, test pro unit testy, doc pro
dokumentaci, bin pro spustitelne soubory a skripty, apod.
- ✅ Export zdrojovych kodu obsahuje radne komentare a nebo dobre citelny zdrojovy kod s vhodne pojmenovanymi
trıdami, promennymi apod.
- ✅ Export zdrojovych kodu obsahuje soubor README.txt, ve kterem je se jmeno projektu, autor a je zde popsano jak
program instalovat a spustit.
- ✅ Export zdrojovych kodu obsahuje konfuguracnı a dalsı soubory potrebne ke spustenı
- ✅ Export zdrojovych kodu aplikace a je ulozen do jednoho archivu s prıponou: .zip

Export databaze
V prıpade, ze vas projekt potrebuje ke spustenı vlastnı relacnı databazi, je treba ji exportovat tak, aby splnovala pravidla
nıze. Postup instalace/importu databaze doporucujeme popsat v souboru README.txt
- ✅ Export databaze obsahuje DDL prıkazy pro vytvorenı databazoveho schematu/modelu.
- ❌ Export databaze obsahuje DML prıkazy pro vlozenı testovacıch zaznamu/dat.
- ✅ Export databaze je uzavren v transakci.
- ❌ Export databaze obsahuje komentar se jmenem projektu, autorem a jeho kontaktnımi udaji.
- ✅ Export databaze je ve formatu SQL v jednom textovem souboru s prıponou: .sql