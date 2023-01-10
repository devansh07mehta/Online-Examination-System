using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineTestApp.App_Code.DAL
{
    public class Admin_DAL
    {
        #region Admin

        public DataSet GetAdminListById(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetAdminById", param);
            return ds;
        }

        public DataSet GetAdminList()
        {

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetAdminList");
            return ds;
        }

        public String SaveAdmin(int Id, String Name, String UserName, String Email, String Password, String Code, String PhoneNumber)
        {
            String msg;

            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Id", Id);
            param[1] = new SqlParameter("@AdminName", Name);
            param[2] = new SqlParameter("@UserName", UserName);
            param[3] = new SqlParameter("@Email", Email);
            param[4] = new SqlParameter("@Password", Password);
            param[5] = new SqlParameter("@Code", Code);
            param[6] = new SqlParameter("@PhoneNumber", PhoneNumber);
            param[7] = new SqlParameter("@Result", SqlDbType.VarChar, 200);
            param[7].Direction = ParameterDirection.Output;


            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_Admin", param);
            msg = param[7].Value.ToString();

            return msg;
        }

        

        #endregion

        #region Teacher

        public String SaveTeacher(int Id, String TeacherName, String UserName, String Email, String Password, String TakeYear, String PhoneNumber)
        {
            String msg;

            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Id", Id);
            param[1] = new SqlParameter("@TeacherName", TeacherName);
            param[2] = new SqlParameter("@UserName", UserName);
            param[3] = new SqlParameter("@Email", Email);
            param[4] = new SqlParameter("@Password", Password);
            
            param[5] = new SqlParameter("@IntakeYear", TakeYear);
            param[6] = new SqlParameter("@PhoneNo", PhoneNumber);
            param[7] = new SqlParameter("@Result", SqlDbType.VarChar, 200);
            param[7].Direction = ParameterDirection.Output;


            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_Teachers", param);
            msg = param[7].Value.ToString();

            return msg;

        }

        public DataSet GetTeacherListById(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetTeacherById", param);
            return ds;
        }

        public DataSet GetTeacherList()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetTeacherList");
            return ds;
        }

        public DataSet DeleteTeacherListById(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_DeleteTeacherById", param);
            return ds;
        }

        #endregion

        #region Student

        public String SaveStudent(int Id, String StudentName, String UserName, String Email, String Password, int ClassId, String TakeYear, String PhoneNumber, int IsActive)
        {
            String msg;

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Id", Id);
            param[1] = new SqlParameter("@StudentName", StudentName);
            param[2] = new SqlParameter("@UserName", UserName);
            param[3] = new SqlParameter("@Email", Email);
            param[4] = new SqlParameter("@Password", Password);
            param[5] = new SqlParameter("@ClassId", ClassId);
            param[6] = new SqlParameter("@IntakeYear", TakeYear);
            param[7] = new SqlParameter("@PhoneNo", PhoneNumber);
            param[8] = new SqlParameter("@IsActive", IsActive);
            param[9] = new SqlParameter("@Result", SqlDbType.VarChar, 200);
            param[9].Direction = ParameterDirection.Output;


            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_Students", param);
            msg = param[9].Value.ToString();

            return msg;

        }

        public DataSet GetStudentListById(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_StudentListById", param);
            return ds;
        }


        public DataSet GetStudentList()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_StudentList");
            return ds;
        }


        public DataSet GetQuestionListByAdmin(int ExamId, int StudentId)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Id", ExamId);
            param[0] = new SqlParameter("@Id", StudentId);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_StudentListById", param);
            return ds;
        }


        public DataSet GetAllExaminationList()
        {
            
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetAllExamList");
            //ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetExamListByStudent", param);
            return ds;
        }

        public DataSet DeleteStudentListById(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_DeleteStudentListById", param);
            return ds;
        }

        #endregion

        #region Subject

        public String SaveSubject(int Id, String Name, String Code)
        {
            String msg;

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Id", Id);
            param[1] = new SqlParameter("@Name", Name);
            param[2] = new SqlParameter("@Code", Code);
            param[3] = new SqlParameter("@Result", SqlDbType.VarChar, 200);
            param[3].Direction = ParameterDirection.Output;

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_Subject", param);
            msg = param[3].Value.ToString();

            return msg;

        }

        public DataSet GetSubjectListById(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetSubjectById", param);
            return ds;
        }


        public DataSet GetSubjectList()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetSubjectList");
            return ds;
        }

        public DataSet DeleteSubjectById(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_DeleteSubjectById", param);
            return ds;
        }
        #endregion

        #region Class

        public String SaveClass(int Id, String ClassName)
        {
            String msg;

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Id", Id);
            param[1] = new SqlParameter("@ClassName", ClassName);
       
            param[2] = new SqlParameter("@Result", SqlDbType.VarChar, 200);
            param[2].Direction = ParameterDirection.Output;

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_Class", param);
            msg = param[2].Value.ToString();

            return msg;

        }

        public DataSet GetClassListById(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetClassById", param);
            return ds;
        }


        public DataSet GetClassList()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetClassList");
            return ds;
        }

        public DataSet DeleteClassById(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_DeleteClassById", param);
            return ds;
        }
        #endregion

    }
}