# Kuchcik
Projekt aplikacji generującej listy przepisów na podstawie posiadanych artykułów spożywczych przeznaczonej na system Windows.

![Screenshot](https://raw.githubusercontent.com/lnarolski/Kuchcik/master/Kuchcik/Screenshots/screenshot1.png)

# Działanie
Zadaniem aplikacji jest tworzenie listy przepisów możliwych do wykonania na podstawie wiedzy o posiadanych składnikach. Plik bazy (db.db) musi znajdować się w tym samym katalogu co aplikacja. Gdy plik nie istnieje to tworzona jest nowa, pusta baza danych.

# Problemy
Aplikacja może nieprawidłowo działać (np. podczas dodawania przepisów lub modyfikacji listy posiadanych składników), gdy w ustawieniach regionalnych systemu Windows jako znak dziesiętny ustawiony jest jakiś egzotyczny znak. Program był testowany dla znaku kropki (.) i przecinka (,) . Możliwe, że gdzieś jeszcze przeoczyłem wprowadzanie poprawek i dla znaku przecinka nadal mogą gdzieś występować problemy.

# TODO
- Lepsza obsługa wyjątków wraz z informacją zwrotną dla użytkownika (KIEDYŚ)
- Poprawienie sposobu na problemy z połączeniem z bazą (aktualnie jest resetowane połączenie i uruchamiany GC) (KIEDYŚ)
