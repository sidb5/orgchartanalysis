using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.BO;

namespace DataAccess
{
    public class PersonDataAccess
    {
        #region Data
        private static readonly List<Person> Data = new List<Person>
        {
            new Person
            {
                Id = 8,
                GivenName = "Trinh",
                FamilyName = "Montejano",
                BossId = 3,
                Title = "Tech Manager",
                Gender = Gender.Unspecified,
                DateOfBirth = DateTime.Parse("1966-09-27")
            },
            new Person
            {
                Id = 1,
                GivenName = "Winfred",
                FamilyName = "Fetzer",
                BossId = null,
                Title = "CEO",
                Gender = Gender.Unspecified,
                DateOfBirth = DateTime.Parse("1927-01-29")
            },
            new Person
            {
                Id = 2,
                GivenName = "Erich",
                FamilyName = "Dandrea",
                BossId = 1,
                Title = "VP of Marketing",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("1927-08-20")
            },
            new Person
            {
                Id = 3,
                GivenName = "Reinaldo",
                FamilyName = "Nisbet",
                BossId =  1,
                Title = "VP of Technology",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("1929-02-07")
            },
            new Person
            {
                Id = 4,
                GivenName = "Alleen",
                FamilyName = "Bufford",
                BossId = 1,
                Title = "VP of HR",
                Gender = Gender.Unspecified,
                DateOfBirth = DateTime.Parse("1932-06-13")
            },
            new Person
            {
                Id = 5,
                GivenName = "Kristyn",
                FamilyName = "Klopfer",
                BossId = 2,
                Title = "Director of Marketing",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Parse("1936-09-26")
            },
            new Person
            {
                Id = 6,
                GivenName = "Sophie",
                FamilyName = "Duhon",
                BossId = 3,
                Title = "Tech Manager",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("1937-11-23")
            },
            new Person
            {
                Id = 7,
                GivenName = "Suanne",
                FamilyName = "Mirabal",
                BossId = 3,
                Title = "Tech Manager",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Parse("1948-04-05")
            },
            new Person
            {
                Id = 9,
                GivenName = "Norah",
                FamilyName = "Maslowski",
                BossId =  4,
                Title = "Tech Manager",
                Gender = Gender.Unspecified,
                DateOfBirth = DateTime.Parse("1966-10-13")
            },
            new Person
            {
                Id = 10,
                GivenName = "Gertrudis",
                FamilyName = "Redford",
                BossId = 6,
                Title = "Tech Lead",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Parse("1967-08-25")
            },
            new Person
            {
                Id = 11,
                GivenName = "Donovan",
                FamilyName = "Tobey",
                BossId = 6,
                Title = "Tech Lead",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("1968-12-26")
            },
            new Person
            {
                Id = 12,
                GivenName = "Rich",
                FamilyName = "Vermeulen",
                BossId = 9,
                Title = "Trainer Lead",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("1969-10-16")
            },
            new Person
            {
                Id = 13,
                GivenName = "Santo",
                FamilyName = "Knupp",
                BossId = 9,
                Title = "HR Manager",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("1972-10-16")
            },
            new Person
            {
                Id = 14,
                GivenName = "Jazmin",
                FamilyName = "Grooms",
                BossId = 12,
                Title = "Trainer",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Parse("1974-03-23")
            },
            new Person
            {
                Id = 15,
                GivenName = "Annelle",
                FamilyName = "Cheeks",
                BossId = 13,
                Title = "Recruiter",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Parse("1978-08-25")
            },
            new Person
            {
                Id = 16,
                GivenName = "Eliza",
                FamilyName = "Harshaw",
                BossId = 12,
                Title = "Trainer",
                Gender = Gender.Unspecified,
                DateOfBirth = DateTime.Parse("1979-08-21")
            },
            new Person
            {
                Id = 17,
                GivenName = "Xiomara",
                FamilyName = "Broaddus",
                BossId = 8 ,
                Title = "Senior Software Developer",
                Gender = Gender.Unspecified,
                DateOfBirth = DateTime.Parse("1980-02-09")
            },
            new Person
            {
                Id = 18,
                GivenName = "Erminia",
                FamilyName = "Jungers",
                BossId = 11,
                Title = "Software Developer",
                Gender = Gender.Unspecified,
                DateOfBirth = DateTime.Parse("1981-09-08")
            },
            new Person
            {
                Id = 19,
                GivenName = "Maria",
                FamilyName = "Moffatt",
                BossId = 10,
                Title = "Software Developer",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Parse("1984-03-18")
            },
            new Person
            {
                Id = 20,
                GivenName = "Tammera",
                FamilyName = "Grimaldo",
                BossId = 10,
                Title = "Senior Software Developer",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Parse("1990-09-24")
            },
            new Person
            {
                Id = 21,
                GivenName = "Sharyl",
                FamilyName = "Das",
                BossId = 10,
                Title = "Software Developer",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Parse("1992-06-18")
            },
            new Person
            {
                Id = 22,
                GivenName = "Shan",
                FamilyName = "Harlan",
                BossId = 8,
                Title = "UI Developer",
                Gender = Gender.Unspecified,
                DateOfBirth = DateTime.Parse("1993-11-15")
            },
            new Person
            {
                Id = 23,
                GivenName = "Mariah",
                FamilyName = "Almeida",
                BossId = 11,
                Title = "QA Tester",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Parse("1997-03-23")
            },
            new Person
            {
                Id = 24,
                GivenName = "Darnell",
                FamilyName = "Kerfien",
                BossId = 11,
                Title = "QA Tester",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("1998-11-10")
            },
            new Person
            {
                Id = 25,
                GivenName = "Janell",
                FamilyName = "Vierra",
                BossId = 11,
                Title = "QA Tester",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Parse("2004-04-22")
            }
        };
        #endregion

        //TODO:  Implement whatever methods are needed to access the data.


        #region DataAccessRepository

        /// <summary>
        /// Find the person by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person GetPersonById(int? id)
        {
            if (id == null) return null;
            return Data.Find(x => x.Id == id);
        }

        #region OrgChartGeneration

        /// <summary>
        /// Generated Org chart that reports to the specified person
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="depth">Depth of the Org tree</param>
        /// <returns></returns>
        
        //Method made virtual for MOQ support
        public virtual OrgChart GetOrgChart(int personId, out int depth)
        {
            
            Person person = Data.Find(x => x.Id == personId);
            depth = 0;
            if (person != null)
            {
                OrgChart org = new OrgChart { Name = person.GivenName + " " + person.FamilyName + "(" + person.Title + ")", Subordinates = new List<OrgChart>() };
                depth = PopulateOrgChart(person, 0, org) ;
                return org;
            }
            return null;
        }

        private int PopulateOrgChart(Person person, int currentDepth, OrgChart node)
        {
            if (person != null)
            {
                int maxdepth = currentDepth;
                List<Person> subordinates = Data.Where(x => x.BossId == person.Id).ToList();
                if (subordinates != null) {
                    foreach (var subordinate in subordinates)
                    {
                        maxdepth = currentDepth + 1;
                        //var temp = new OrgChart { Name = person.GivenName + " " + person.FamilyName + "(" + person.Title + ")", Subordinates = new List<OrgChart>() };
                        var subordinateOrgChart = new OrgChart { Name = subordinate.GivenName + " " + subordinate.FamilyName + "(" + subordinate.Title + ")", Subordinates = new List<OrgChart>() };
                        node.Subordinates.Add(subordinateOrgChart);
                        int depth = PopulateOrgChart(subordinate, maxdepth, subordinateOrgChart);
                        if (depth > maxdepth) maxdepth = depth;
                    }
                }

                return maxdepth;
            }
            return 0;
        }


        #endregion

        #endregion
    }

}