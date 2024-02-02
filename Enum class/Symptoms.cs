using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal enum Symptoms
    {   // Id postavljen na 100 zbog lakseg pronalaska odgovarajuce specijalisticke ordinacije i lakse dodavanje novih simptoma
        //Opća Medicina/Interna Medicina:
        Anoreksija = 100,
        Gubitak_težine,
        Drhtavica,
        Umor,
        Malaksalost,
        Hipotermija,
        Žutica,
        Slabost_mišića,
        Pireksija,
        Znojenje,
        Oticanje,
        Dobijanje = 111,

        //Kardiologija:

        Aritmija = 200,
        Bol_u_prsima,
        Klaudikacija,
        Palpitacije,
        Tahikardija = 204,

        //Otorinolaringologija 

        Suha_usta = 300,
        Krvarenje_iz_nosa,
        Loš_zadah,
        Gubitak_sluha,
        Tinitus,
        Iscjetak_iz_nosa,
        Bol_u_uhu,
        Otoreja,
        Bolno_grlo,
        Zubobolja,
        Trizmus = 310,

        //Gastroenterologija:

        Bol_u_abdomenu = 400,
        Nadutost,
        Podrigivanje,
        Hematemesis,
        Melena,
        Hematohezija,
        Zatvor,
        Proljev,
        Disfagija,
        Dispepsija,
        Fekalna_inkontinencija,
        Nadimanje,
        Zgaravica,
        Mučnina,
        Odinofagija,
        Piroza,
        Steatoreja,
        Povraćanje = 417,

        //Dermatologija:

        Aabrazija = 500,
        Anasarca,
        Krvarenje_na_kozi,
        Mmjehuri,
        Ssvrbez,
        Laceracija,
        Osip,
        Urtikarija,
        Alopecija,
        Hirzutizam,
        Hipertrihoza = 510,

        //Neurologija:

        Akalkulija = 600,
        Agnozija,
        Aleksija,
        Amnezija,
        Anomija,
        Anosognozija,
        Afazija,
        Apraksija,
        Ataksija,
        Katapleksija,
        Konfuzija,
        Disartrija,
        Disdiadokokineza,
        Disgrafija,
        Halucinacija,
        Glavobolja,
        Akinezija,
        Bradikinezija,
        Akatizija,
        Atetoza,
        Balizmus,
        Blefarospazam,
        Koreja,
        Distonija,
        Fascikulacija,
        Grcevi_u_mišićima,
        Mioklonus,
        Opsoklonus,
        Tik,
        Tremor,
        Nesanica,
        Gubitak_svijesti,
        Ukočenost_vrata,
        Opisthotonus,
        Paraliza,
        Parestezija = 635,

        //Ginekologija:

        Trudnoca = 700,
        Bolu_zdjelici = 701,

        //Oftalmologija:

        Zamagljen_vid = 800,
        Dvostruki_vid,
        Eksophthalmos,
        Midrijaza,
        Nioza,
        Nistagmus = 805,

        //Psihijatrija:

        Amuzija = 900,
        Anhedonija,
        Anksioznost,
        Apatija,
        Konfabulacija,
        Depresija,
        Deluzija,
        Euforija,
        Razdražljivost,
        Manija,
        Paranoja,
        Fobije,
        Suicidalnost = 912
    }
}
