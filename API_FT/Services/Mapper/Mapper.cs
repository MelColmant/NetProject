using API = API_FT.Models;
using FTDAL = DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_FT.Services.Mapper
{
    public static class Mapper
    {
        public static FTDAL.User ToDAL(this API.User user)
        {
            return new FTDAL.User
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }

        public static API.User ToAPI(this FTDAL.User user)
        {
            return new API.User
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }

        public static FTDAL.Tree ToDAL(this API.Tree tree)
        {
            return new FTDAL.Tree
            {
                TreeId = tree.TreeId,
                TreeName = tree.TreeName,
                Description = tree.Description,
                UserId = tree.UserId
            };
        }

        public static API.Tree ToAPI(this FTDAL.Tree tree)
        {
            return new API.Tree
            {
                TreeId = tree.TreeId,
                TreeName = tree.TreeName,
                Description = tree.Description,
                UserId = tree.UserId
            };
        }

        public static FTDAL.Person ToDAL(this API.Person person)
        {
            return new FTDAL.Person
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                BirthDate = person.BirthDate,
                DeathDate = person.DeathDate,
                TreeId = person.TreeId
            };
        }

        public static API.Person ToAPI(this FTDAL.Person person)
        {
            return new API.Person
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                BirthDate = person.BirthDate,
                DeathDate = person.DeathDate,
                TreeId = person.TreeId
            };
        }

        public static FTDAL.Relationship ToDAL(this API.Relationship relationship)
        {
            return new FTDAL.Relationship
            {
                RelationshipId = relationship.RelationshipId,
                Person1Id = relationship.Person1Id,
                Person2Id = relationship.Person2Id,
                StartDate = relationship.StartDate,
                EndDate = relationship.EndDate,
                IsUnisex = relationship.IsUnisex,
                RelationshipTypeCode = relationship.RelationshipTypeCode
            };
        }

        public static API.Relationship ToAPI(this FTDAL.Relationship relationship)
        {
            return new API.Relationship
            {
                RelationshipId = relationship.RelationshipId,
                Person1Id = relationship.Person1Id,
                Person2Id = relationship.Person2Id,
                StartDate = relationship.StartDate,
                EndDate = relationship.EndDate,
                IsUnisex = relationship.IsUnisex,
                RelationshipTypeCode = relationship.RelationshipTypeCode
            };
        }
    }
}