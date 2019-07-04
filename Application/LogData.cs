using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Infrastructure
{
    public class LogData : ILogData
    {
        public TaskEntry CreateTaskEntry()
        {
            throw new NotImplementedException();
        }

        public TaskLog GetTaskLogDataById(string id)
        {
            throw new NotImplementedException();
        }

        public TaskLog[] SearchTaskLogDataByDate()
        {
            throw new NotImplementedException();
        }

        public TaskEntry UpdateTaskEntry()
        {
            throw new NotImplementedException();
        }
    }
}
