using Azure;
using CollegeManagement.Data;
using CollegeManagement.Repository.Interface;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Repository
{
    public class CollegeRepository : ICollegeRepository
    {
        private readonly CollegeDbContext _collegeDbContext;
        public CollegeRepository(CollegeDbContext collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }
        public List<College> GetAll()
        {
            string sql = "SELECT * FROM FacultyDetails";
            using (var connection = _collegeDbContext.CreateConnection())
            {
                connection.Open();
                return connection.Query<College>(sql).ToList();
            }
        }
        public College Create(College college)
        {
            string sql = "INSERT INTO FacultyDetails VALUES('" + college.FacultyName + "','" + college.FacultyQualification + "','" + college.FacultyPhoneNumber + "','" + college.FacultyEmail + "','" + college.FacultyDepartment + "','" + college.FacultySubject + "','" + college.FacultyClass + "','" + college.StudentsCount + "')";
            using (var connection = _collegeDbContext.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql);
                return college;
            }
        }
        public List<College> Update(int Id, College college)
        {
            string sql = "Update FacultyDetails Set "
                         + "FacultyName = '"
                         + college.FacultyName
                         + "',FacultyQualification = '"
                         + college.FacultyQualification
                         + "',FacultyPhoneNumber = '"
                         + college.FacultyPhoneNumber
                         + "',FacultyEmail = '"
                         + college.FacultyEmail
                         + "', FacultyDepartment = '"
                         + college.FacultyDepartment
                         + "',FacultySubject = '"
                         + college.FacultySubject
                         + "',FacultyClass = '"
                         + college.FacultyClass
                         + "',StudentsCount = '"
                         + college.StudentsCount
                         + "' where Id = "
                         + Id
                         + "";
            using (var connection = _collegeDbContext.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql);
                return connection.Query<College>("select * from FacultyDetails Where Id = " + Id).ToList();
            }

        }


        public string UpdateName(int Id, College college) 
        {
           string sql = "Update FacultyDetails Set FacultyName = '" + college.FacultyName + "' Where Id = " + Id ;
            using (var connection = _collegeDbContext.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql);
                return "Name Changed Successfully";
            }
        }



        public string Delete(int Id)
        {
            string sql = "delete from FacultyDetails where id = " + Id;
            using (var connection = _collegeDbContext.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql);
                return "Successfully Deleted";
            }
        }
        public List<College> GetById(int Id)
        {
                string sql = "select * from FacultyDetails where Id = " + Id;


                using (var connection = _collegeDbContext.CreateConnection())
                {
                    connection.Open();
                    connection.Execute(sql);
                    return connection.Query<College>("select * from FacultyDetails Where Id = " + Id).ToList();
                }
        }



        public List<College> GetBySelectedRow(string Search)
        {
            string sql = "select * from FacultyDetails where FacultyName like '"
                         + Search
                         + "%"
                         + "' or FacultyEmail like '"
                         + Search
                         + "%"
                         + "' or FacultyQualification like '"
                         + Search
                         + "%"
                         + "' or FacultyDepartment like '"
                         + Search
                         + "%"
                         + "' or FacultySubject like '"
                         + Search
                         + "%"
                         + "' or FacultyClass like '"
                         + Search
                         + "%"
                         + "'";
            using (var connection = _collegeDbContext.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql);
                return connection.Query<College>("select * from FacultyDetails where FacultyName like '"
                                                 + Search
                                                 + "%"
                                                 + "' or FacultyEmail like '"
                                                 + Search
                                                 + "%"
                                                 + "' or FacultyQualification like '"
                                                 + Search
                                                 + "%"
                                                 + "' or FacultyDepartment like '"
                                                 + Search
                                                 + "%"
                                                 + "' or FacultySubject like '"
                                                 + Search
                                                 + "%"
                                                 + "' or FacultyClass like '"
                                                 + Search
                                                 + "%"
                                                 + "'").ToList();
            }
        }
        public List<College> Offset(int limit, int offset)
        {
            string sql = "SELECT * FROM FacultyDetails ORDER BY Id  OFFSET " + offset + " Rows FETCH Next " + limit + " ROWS only" ;
            using (var connection = _collegeDbContext.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql);
                return connection.Query<College>("SELECT * FROM FacultyDetails ORDER BY Id  OFFSET "
                                                 + offset
                                                 + " Rows FETCH Next "
                                                 + limit
                                                 + " ROWS only").ToList();
            }
        }



        public List<College> Omit(int omit)
        {
            string sql = "SELECT * FROM FacultyDetails ORDER BY Id OFFSET " + omit + " ROWS ";
            using (var connection = _collegeDbContext.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql);
                return connection.Query<College>("SELECT * FROM FacultyDetails ORDER BY Id OFFSET " + omit + " ROWS ").ToList();
            }
        }


        public List<College> Pagination(int page, int pageSize) 
        {
            string sql = "Select * FROM FacultyDetails ORDER BY Id OFFSET ( " + page + " -1 ) * " + pageSize + " ROWS FETCH NEXT " + pageSize + " ROWS ONLY";
            using (var connection = _collegeDbContext.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql);
                return connection.Query<College>("Select * FROM FacultyDetails ORDER BY Id OFFSET ( "
                                                 + page
                                                 + " -1 ) * "
                                                 + pageSize
                                                 + " ROWS FETCH NEXT "
                                                 + pageSize
                                                 + " ROWS ONLY").ToList();
            }
        }




        public List<College> Filter(string Search, int page, int pageSize) 
        {
            string sql = "select * from FacultyDetails where FacultyName like '"
                         + Search
                         + "%"
                         + "' or FacultyEmail like '"
                         + Search
                         + "%"
                         + "' or FacultyQualification like '"
                         + Search
                         + "%"
                         + "' or FacultyDepartment like '"
                         + Search
                         + "%"
                         + "' or FacultySubject like '"
                         + Search
                         + "%"
                         + "' or FacultyClass like '"
                         + Search
                         + "%"
                         + "'";
            string sql1 = "Select * FROM FacultyDetails ORDER BY Id OFFSET ( "
                          + page
                          + " -1 ) * "
                          + pageSize
                          + " ROWS FETCH NEXT "
                          + pageSize
                          + " ROWS ONLY";
            using (var connection = _collegeDbContext.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql);
                connection.Execute(sql1);
                return connection.Query<College>("select * from FacultyDetails where FacultyName like '"
                                                 + Search
                                                 + "%"
                                                 + "' or FacultyEmail like '"
                                                 + Search
                                                 + "%"
                                                 + "' or FacultyQualification like '"
                                                 + Search
                                                 + "%"
                                                 + "' or FacultyDepartment like '"
                                                 + Search
                                                 + "%"
                                                 + "' or FacultySubject like '"
                                                 + Search
                                                 + "%"
                                                 + "' or FacultyClass like '"
                                                 + Search
                                                 + "%"
                                                 + "' INTERSECT Select * FROM FacultyDetails ORDER BY Id OFFSET ( "
                                                 + page
                                                 + " -1 ) * "
                                                 + pageSize
                                                 + " ROWS FETCH NEXT "
                                                 + pageSize
                                                 + " ROWS ONLY").ToList() ;
            }
        }


        public List<College> Cursor(int page, int pageSize)
        {
            string sql = "Select * FROM FacultyDetails ORDER BY Id OFFSET ( " + page + " -1 ) * " + pageSize + " ROWS FETCH NEXT " + pageSize + " ROWS ONLY";
            
            using (var connection = _collegeDbContext.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql);
                
                return connection.Query<College>(sql).ToList();
            }
            
        }

        public List<College> Info(int page, int pageSize)
        {
            string sql = "Select * FROM FacultyDetails ORDER BY Id OFFSET ( " + page + " -1 ) * " + pageSize + " ROWS FETCH NEXT " + pageSize + " ROWS ONLY";
            using (var connection = _collegeDbContext.CreateConnection())
            {
                connection.Open();
                connection.Execute(sql);
                return connection.Query<College>(sql).ToList();
            }
        }

        public PageInfo pageInfos()
        {
            PageInfo info = new PageInfo();
            info.PageNum = 1;
            string sql = "select count(*) from FacultyDetails";

            using (var connection = _collegeDbContext.CreateConnection())
            {
                connection.Open();
                var count = connection.ExecuteScalar<int>(sql);
                info.TotalCount = count;
                info.TotalPages = 5;
                info.NestPages = 2;
                return info;
            }
        }
    }
}

