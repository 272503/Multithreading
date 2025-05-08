# Multithreading – Aplikacja WinForms z porównaniem metod wielowątkowości
Projekt przedstawia porównanie wydajności dwóch metod realizacji wielowątkowego mnożenia macierzy w języku C# w środowisku .NET: klasycznych wątków (Thread) oraz Parallel.For. Aplikacja została zbudowana jako prosty interfejs WinForms.

## Spis treści
- Opis
- Struktura projektu
- Wymagani
- Uruchamianie
- Proces badawczy
- Wnioski

### Opis
Aplikacja to narzędzie desktopowe stworzone w technologii Windows Forms (.NET), służące do porównania wydajności dwóch podejść do wielowątkowego mnożenia macierzy:

Parallel.For – wysokopoziomowe API z biblioteki Task Parallel Library, umożliwiające automatyczny podział pracy między wątki.

Thread – ręczne tworzenie i synchronizacja wątków, przypisujących każdemu zakresowi wierszy oddzielny wątek.

#### Funkcjonalność
Po uruchomieniu użytkownik:

1. Wprowadza liczbę wątków (np. 2, 4, 8) w polu tekstowym.

2. Naciska przycisk „Wykonaj”, co uruchamia eksperyment.

3. Dla kolejnych rozmiarów macierzy (100x100, 200x200, ..., 2000x2000) wykonywane jest:

- 5 powtórzeń mnożenia przy użyciu Parallel.For

- 5 powtórzeń mnożenia przy użyciu klasy Thread

4. Mierzony jest średni czas wykonania dla każdej z metod.

5. Wyniki (średni czas dla każdego rozmiaru i metody) są prezentowane w formie tekstowej w oknie aplikacji.

#### Detale techniczne
- Macierze generowane są losowo z liczbami całkowitymi od 1 do 9.
- Metoda Parallel.For dynamicznie dzieli zakresy wierszy pomiędzy dostępne wątki, wykorzystując MaxDegreeOfParallelism.
- W metodzie Thread, liczba wątków jest ustalana przez użytkownika – każdemu wątkowi przypisuje się z góry wyliczony zakres wierszy.
- Czas mierzony jest za pomocą Stopwatch, a wyniki wstawiane są do pola txtResults.

### Struktura projektu
Multithreading/
├── Form1.cs               – główny formularz aplikacji
├── MatrixOperations.cs    – logika mnożenia macierzy i obsługa wielowątkowości
├── Program.cs             – punkt wejściowy aplikacji
├── Form1.Designer.cs      – projekt graficzny formularza
├── Form1.resx             – zasoby formularza
├── Multithreading.csproj – plik projektu

### Wymagania
- Visual Studio 2019 lub nowsze
- .NET Framework 4.7.2 lub nowszy
- Windows (WinForms)

### Uruchamianie
1. Sklonuj repozytorium:
```bash
git clone https://github.com/272503/Multithreading.git
```
2. Otwórz folder Multithreading w Visual Studio.
3. Uruchom projekt (F5), a następnie korzystaj z przycisków interfejsu, aby uruchomić mnożenie macierzy i porównać czas wykonania.

### Proces badawczy
Celem eksperymentu było porównanie dwóch podejść do wielowątkowości przy intensywnych obliczeniach (mnożenie dużych macierzy). Dla różnych rozmiarów macierzy mierzono czas działania każdej metody (w ms).
Zakres testowanych macierzy:
- od 100×100 do 2000×2000
Zebrane dane zostały następnie przeanalizowane w Excelu i przedstawione w formie wykresów porównawczych.

## Wnioski
- Dla mniejszych macierzy (np. 100×100, 200×200) różnice w czasie wykonania między metodą Parallel.For a Thread są niewielkie i mogą się wahać w zależności od obciążenia procesora.
- Przy większych rozmiarach macierzy (np. 1000×1000, 2000×2000) metoda Thread (ręczne tworzenie wątków) okazała się wydajniejsza niż Parallel.For.
- Może to wynikać z dodatkowych narzutów wewnętrznych związanych z zarządzaniem pulą zadań w Parallel.For, które przy bardzo intensywnym obliczeniowo zadaniu (jakim jest mnożenie dużych macierzy) powodują opóźnienia.
- Ręczne dzielenie zakresów wierszy i niezależne uruchamianie wątków pozwala dokładniej kontrolować rozkład pracy, co przy dużym obciążeniu może przekładać się na lepszą efektywność.
#### Wniosek ogólny: 
W kontekście tego konkretnego problemu (mnożenie dużych macierzy) i konfiguracji testowej, klasyczne wątki (Thread) zapewniają lepszą wydajność niż Parallel.For. Nie zawsze nowocześniejsze API jest bardziej efektywne – warto przeprowadzać pomiary w zależności od konkretnego zastosowania.

### Wykresy:
![image](https://github.com/user-attachments/assets/5daf71f4-6c50-4619-9cac-5ccaae1acb00)

![image](https://github.com/user-attachments/assets/340b9c61-af3d-470c-9981-905792fe03e6)

![image](https://github.com/user-attachments/assets/d850a4f0-30ac-40cc-97f7-8c664fd44408)

