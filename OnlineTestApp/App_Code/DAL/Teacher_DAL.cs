using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineTestApp.App_Code
{
    public class Teacher_DAL
    {
        #region Examination

        public String SaveExamination(int Id, int SubjectId, String ExamName, String Instruction, int DurationInMinute, int PassMark, DateTime ExamStart, DateTime ExamEnd, int ClassId,int Expire)
        {
            String msg;

            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@Id", Id);
            param[1] = new SqlParameter("@SubjectId", SubjectId);
            param[2] = new SqlParameter("@ExamName", ExamName);
            param[3] = new SqlParameter("@Instruction", Instruction);
            param[4] = new SqlParameter("@DurationInMinute", DurationInMinute);
            param[5] = new SqlParameter("@PassMark", PassMark);
            param[6] = new SqlParameter("@ExamStart", ExamStart);
            param[7] = new SqlParameter("@ExamEnd", ExamEnd);
            param[8] = new SqlParameter("@ClassId", ClassId);
            param[9] = new SqlParameter("@IsExpire", Expire);
            param[10] = new SqlParameter("@Result", SqlDbType.VarChar, 200);
            param[10].Direction = ParameterDirection.Output;


            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_Examination", param);
            msg = param[10].Value.ToString();

            return msg;

        }

        public DataSet GetExaminationById(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetExaminationById", param);
            return ds;
        }

        public DataSet GetExaminationList()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetExaminationList");
            return ds;
        }

        public DataSet GetExaminationListByDate()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetExaminationListByDate");
            return ds;
        }

        public DataSet GetExaminationListByStudentId(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            //ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetAppearedExamListByStudent", param);
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetExamListByStudent", param);
            return ds;
        }


        public DataSet GetAppearedExaminationListByStudentId(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetAppearedExamListByStudent", param);
            //ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetExamListByStudent", param);
            return ds;
        }

        public DataSet DeleteExaminationById(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_DeleteExaminationById", param);
            return ds;
        }

        #endregion


        #region Question


        public DataSet SaveQuestions(int Id, String Question, String OptionA, String OptionB, String OptionC, String OptionD, int PassMark,int ExamId,  int AnswerID)
        {
            String msg;

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Id", Id);
            param[1] = new SqlParameter("@Question", Question);
            param[2] = new SqlParameter("@optionA", OptionA);
            param[3] = new SqlParameter("@optionB", OptionB);
            param[4] = new SqlParameter("@optionC", OptionC);
            param[5] = new SqlParameter("@optionD", OptionD);
            param[6] = new SqlParameter("@QuestionAnswer", AnswerID);
            param[7] = new SqlParameter("@Marks", PassMark);
            param[8] = new SqlParameter("@AvailableExam", ExamId);
            //param[9] = new SqlParameter("@Result", SqlDbType.VarChar, 200);
            //param[9].Direction = ParameterDirection.Output;


            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_Question", param);
            //msg = param[9].Value.ToString();

            return ds;

        }

        public DataSet GetQuestionById(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetQuestionById", param);
            return ds;
        }

        public DataSet GetQuestionList()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_GetQuestionList");
            return ds;
        }

        public DataSet DeleteQuestionById(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", ID);

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_DeleteQuestionById", param);
            return ds;
        }

        #endregion
    }
}