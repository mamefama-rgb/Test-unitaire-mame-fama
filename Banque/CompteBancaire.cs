using System;

namespace CompteBanqueNS
{

    public class CompteBancaire
    {
        private string m_nomClient;
        private double m_solde;
        private bool m_bloque = false;


        public CompteBancaire(string nomClient, double solde)
        {
            m_nomClient = nomClient;
            m_solde = solde;
        }

        public string NomClient
        {
            get { return m_nomClient; }
        }

        public double Solde
        {
            get { return m_solde; }
        }

        public void Débiter(double montant)
        {
            if (m_bloque)
            {
                throw new Exception("Compte bloqué");
            }

            if (montant > m_solde)
            {
                throw new ArgumentOutOfRangeException("montant", "Montant débité doit être supérieur ou égal au solde disponible");
            }

            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("montant", "Montant doit être positif");
            }

            m_solde -= montant; 
        }
    }
}