using StatikusOsztalyokOOP;

//Veletlen v = new Veletlen();      Statikus osztályból nem lehet példányt létrehozni
for (int i = 0; i < 10; i++)
{
  
    Console.WriteLine(Veletlen.VelTeljesNev(Veletlen.NEM.FERFI));
    Console.WriteLine(Veletlen.VelTeljesNev(Veletlen.NEM.NO));

}
for (int i = 0;i < 10;i++)
{
    Console.WriteLine(Veletlen.VelKarakter('A', 'X'));
}

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(Veletlen.VelDatum(2000, 2100));
}
Console.WriteLine(Veletlen.velEmail(Veletlen.VelTeljesNev(Veletlen.NEM.NO)));
Console.WriteLine(Veletlen.velEmail(Veletlen.VelTeljesNev(Veletlen.NEM.FERFI)));
Console.WriteLine(Veletlen.velMobil());
Console.WriteLine(Veletlen.velSportag());
Console.WriteLine(Veletlen.velSportegyesulet());

