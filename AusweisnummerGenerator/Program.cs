string behördenkennzahl = Ask("Behördenkennzahl (Bad Kreuznach = 2053):") ?? "2053";
string laufendeNummer = Ask("Fortlaufende Ausweisnummer (10000 - 99999):") ?? "49999";
string geburtsDatum = Ask("Geburtsdatum 19(JahrMonatTag) 980502 = 1998 Mai 2:") ?? "980502";
string ablaufDatum = Ask("Ablaufdatum 20(JahrMonatTag):") ?? "230502";

string? Ask(string what) {
    Console.Write(what + "\n");
    string? response = Console.ReadLine();
    return string.IsNullOrWhiteSpace(response) ? null : response;
}


int[] gewicht = new[] { 7, 3, 1 };

int prüfziffer(string block) {
    int summe = 0;

    for (int i = 0; i < block.Length; i++) {
        summe += int.Parse(block[i].ToString()) * gewicht[i % 3];
    }

    return summe % 10;
}

int block1 = prüfziffer(behördenkennzahl + laufendeNummer);
int block2 = prüfziffer(geburtsDatum);
int block3 = prüfziffer(ablaufDatum);

int gesamt = prüfziffer(behördenkennzahl + laufendeNummer + block1.ToString() + geburtsDatum + block2.ToString() + ablaufDatum + block3.ToString());

// https://de.wikipedia.org/wiki/Ausweisnummer

Console.WriteLine(@$"
Alter Personalausweis
{behördenkennzahl+laufendeNummer+block1.ToString()}D<<{geburtsDatum+block2.ToString()}<{ablaufDatum+block3.ToString()}<<<<<<<{gesamt}

Neuer Personalausweis (BETA Nicht getestet)
IDD<<{behördenkennzahl+laufendeNummer+block1.ToString()}<<<<<<<<<<<<<<<
<<{geburtsDatum+block2.ToString()}<{ablaufDatum+block3.ToString()}D<<2108<<<<<<<{gesamt}

Drücke eine Taste um zu beenden");
Console.ReadLine();
