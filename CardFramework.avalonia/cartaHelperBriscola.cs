/*
  *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 1.1.3
 *
 *  Created by Giulio Sorrentino (numerone) on 29/01/23.
 *  Copyright 2023 Some rights reserved.
 *
 */


namespace org.altervista.numerone.framework.briscola
{
    public class CartaHelper : org.altervista.numerone.framework.CartaHelper {
		private readonly UInt16 CartaBriscola;
		public CartaHelper(UInt16 briscola) { CartaBriscola = briscola; }
		public UInt16 GetSeme(UInt16 Carta) {
			return (UInt16)(Carta / 10);
		}
		public UInt16 GetValore(UInt16 Carta) {
			return (UInt16)(Carta % 10);
		}
		public UInt16 GetPunteggio(UInt16 Carta) {
			UInt16 valore = 0;
			switch (Carta % 10) {
				case 0: valore = 11; break;
				case 2: valore = 10; break;
				case 9: valore = 4; break;
				case 8: valore = 3; break;
				case 7: valore = 2; break;
			}
			return valore;
		}
        public string GetSemeStr(UInt16 carta, String mazzo, string s0, string s1, string s2, string s3, string s4, string s5, string s6, string s7)
        {
            string s = "a";
            if (mazzo == "Bergamasco" || mazzo == "Bolognese" || mazzo == "Bresciano" || mazzo == "Napoletano" || mazzo == "Romagnolo" || mazzo == "Sardo" || mazzo == "Siciliano" || mazzo == "Trientino" || mazzo == "Trevigiano" || mazzo == "Trentino" || mazzo == "Triestino")
                switch (carta / 10)
                {
                    case 0: s = s0 as String; break;
                    case 1: s = s1 as String; break;
                    case 2: s = s2 as String; break;
                    case 3: s = s3 as String; break;
					default: throw new ArgumentException("Chiamata a getsemestr con seme > 3");
                }
            else
                switch (carta / 10)
                {
                    case 0: s = s4 as String; break;
                    case 1: s = s5 as String; break;
                    case 2: s = s6 as String; break;
                    case 3: s = s7 as String; break;
                    default:
						throw new ArgumentException("Chiamata a getsemestr con seme > 3");
                }
            return s;
        }


        public UInt16 GetNumero(UInt16 seme, UInt16 valore) {
			if (seme > 4 || valore > 9)
				throw new ArgumentException($"Chiamato CartaHelperBriscola::getNumero con seme={seme} e valore={valore}");
			return (UInt16)(seme * 10 + valore);
		}

		public Carta GetCartaBriscola() { return Carta.GetCarta(CartaBriscola); }

		public int CompareTo(UInt16 Carta, UInt16 Carta1) {
			UInt16 punteggio = GetPunteggio(Carta),
				   punteggio1 = GetPunteggio(Carta1),
				   valore = GetValore(Carta),
				   valore1 = GetValore(Carta1),
				   semeBriscola = GetSeme(CartaBriscola),
				   semeCarta = GetSeme(Carta),
					  semeCarta1 = GetSeme(Carta1);
			if (punteggio < punteggio1)
				return 1;
			else if (punteggio > punteggio1)
				return -1;
			else {
				if (valore < valore1 || (semeCarta1 == semeBriscola && semeCarta != semeBriscola))
					return 1;
				else if (valore > valore1 || (semeCarta == semeBriscola && semeCarta1 != semeBriscola))
					return -1;
				else
					return 0;
			}
		}
	}
}