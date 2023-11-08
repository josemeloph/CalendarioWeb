﻿using System;

namespace CalendarioWeb.Models
{
    public class Calendario
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int[] Inicio_Fim {  get; set; }
        public int[] QteDiasMes { get; set; } = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public int[,] Dias {  get; set; }

        public int PrimeiroDiaMes()
        {
            DateTime data = new DateTime(Ano, Mes, 1);
            int diaSemana = (int)data.DayOfWeek;
            return diaSemana;
        }

        public int[,] GerarCalendario()
        {
            if ((Ano % 4 == 0 && Ano % 100 != 0) || Ano % 400 == 0) QteDiasMes[1] = 29;
            int[,] Dias = new int[6, 7];
            int mesAtual = Mes - 1;
            int mesAnterior = mesAtual == 0 ? 11 : mesAtual - 1;
            for (int d = 0; d < 7; d++)
            {
                if (d < PrimeiroDiaMes()) Dias[0, d] = QteDiasMes[mesAnterior] - PrimeiroDiaMes() + d + 1;
                else Dias[0, d] = d - PrimeiroDiaMes() + 1;
            }
            Inicio_Fim = new int[3];
            Inicio_Fim[0] = PrimeiroDiaMes();
            int dia = Dias[0, 6] + 1;
            int diaMesSeguinte = 0;
            for (int i = 1; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (dia <= QteDiasMes[mesAtual])
                    {
                        Dias[i, j] = dia;
                        dia++;
                    }
                    else
                    {
                        if(diaMesSeguinte == 0)
                        {
                            Inicio_Fim[1] = i;
                            Inicio_Fim[2] = j - 1;
                        }
                        diaMesSeguinte++;
                        Dias[i, j] = diaMesSeguinte;
                    }
                }
            }
            return Dias;
        }
    }
}
