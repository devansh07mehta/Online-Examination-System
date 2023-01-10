using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineTestApp.App_Code.DAL
{
    public class Student_DAL
    {
        public DataSet SaveAnswer(int StudentId,int ExamId,int QuestionId,int Answer)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@StudentId", StudentId);
            param[1] = new SqlParameter("@ExamId", ExamId);
            param[2] = new SqlParameter("@QuestionId", QuestionId);
            param[3] = new SqlParameter("@SelectedAnswer", Answer);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_Answer", param);
            return ds;
        }

        public DataSet GetDurationByExamId(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ExamId", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetDurationByExamId", param);
            return ds;
        }

        public DataSet GetExaminationByStudentID(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetExamListByStudent", param);
            return ds;
        }

        public DataSet GetQuestionListByExamID(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetQuestionListByExamId", param);
            return ds;
        }


        public DataSet GetQuestionListByQuestionId(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetQuestionById", param);
            return ds;
        }

        public DataSet GetExamResultListById(int StudentId,int ExamId)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@StudentId", StudentId);
            param[1] = new SqlParameter("@ExamId", ExamId);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetExamResultListById", param);
            return ds;
        }

        public DataSet UpdateExpire(int StudentId, int ExamId,int IsExpire)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@StudentId", StudentId);
            param[1] = new SqlParameter("@ExamId", ExamId);
            param[2] = new SqlParameter("@IsExpire", IsExpire);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_UpdateExpire", param);
            return ds;
        }

    }
}