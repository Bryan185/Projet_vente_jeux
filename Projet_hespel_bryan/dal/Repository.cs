﻿using Projet_hespel_bryan.DTO;
using Projet_hespel_bryan.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projet_hespel_bryan.Models;

namespace Projet_hespel_bryan.dal
{
    public class Repository : IRepository
    {
        private BoutiqueContext db = new BoutiqueContext();
        public LoginDTO Authentifier(string email, string password)
        {
            var logg = (from r in db.Users where r.mail == email && r.password == password select new LoginDTO { nom = r.nom, prenom = r.prenom, id_user = r.userID,adresse =  r.adresse, password = r.password, mail = r.mail }).FirstOrDefault();
            return logg;
            throw new NotImplementedException();
        }
        public List<ArticleDTO> construct (int id)
        {
            var logg = (from r in db.Articles where r.constructeurID == id select new ArticleDTO { nom = r.nom_article, prix = r.prix});
            return logg.ToList();
        }

        public List<VenteDTO> vente (int id)
        {
            var logg = (from r in db.Articles where r.userID == id select new VenteDTO {articleID = r.articleID,nom_article = r.nom_article,type = r.type, etat = r.etat, userID = r.userID,prix = r.prix, date_transaction = r.date_transaction,date_mise = r.date_mise });
            return logg.ToList();
        }

        public List<ArticleDTO> catego (int id)
        {
            var logg = (from r in db.Articles where r.categorieID == id select new ArticleDTO { nom = r.nom_article, prix = r.prix });
            return logg.ToList();
        }
     
       

       
    }
}