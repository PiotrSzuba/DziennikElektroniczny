namespace DziennikElektroniczny.Utils
{
    public static class SetStudTeacherValues
    {
        public static void setVals(ref int teacherId, ref int studentId,int personid,int Role)
        {
            if(Role == 3)
            {
                teacherId = personid;
            }
            if(Role == 2) //
            {
                studentId = personid;
            }
            if (Role == 1)
            {
                studentId = personid;
            }
        }
    }
}
