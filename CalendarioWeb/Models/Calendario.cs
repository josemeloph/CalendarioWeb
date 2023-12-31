﻿using System;

namespace CalendarioWeb.Models
{
    public class Calendario
    {
        public DateTime Data { get; set; }
        public DateTime[,] Dias { get; set; } = new DateTime[6, 7];


        public void GerarCalendario()
        {
            DateTime data = Data;
            int ano = data.Year;
            int mes = data.Month;
            int qteDias = DateTime.DaysInMonth(ano, mes);
            int qteDiasMesAnterior = DateTime.DaysInMonth(ano, mes == 1 ? 12 : mes - 1);
            int primeiroDiaMes = (int)new DateTime(ano, mes, 1).DayOfWeek;
            for (int d = 0; d < 7; d++)
            {
                if (d < primeiroDiaMes)
                {
                    if(mes == 1) Dias[0, d] = new DateTime(ano - 1, 12, qteDiasMesAnterior - primeiroDiaMes + d + 1);
                    else Dias[0, d] = new DateTime(ano, mes - 1, qteDiasMesAnterior - primeiroDiaMes + d + 1);
                }
                else Dias[0, d] = new DateTime(ano, mes, d - primeiroDiaMes + 1);
            }
            int dia = Dias[0, 6].Day + 1;
            int diaMesSeguinte = 0;
            for (int i = 1; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (dia <= qteDias)
                    {
                        Dias[i, j] = new DateTime(ano, mes, dia);
                        dia++;
                    }
                    else
                    {
                        diaMesSeguinte++;
                        if (mes == 12) Dias[i, j] = new DateTime(ano + 1, 1, diaMesSeguinte);
                        else Dias[i, j] = new DateTime(ano, mes + 1, diaMesSeguinte);
                    }
                }
            }
        }

    }
}
