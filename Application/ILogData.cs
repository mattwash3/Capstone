using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public interface ILogData
    {
        TaskLog GetTaskLogDataById(string id);
        TaskLog[] SearchTaskLogDataByDate();
        TaskEntry CreateTaskEntry();
        TaskEntry UpdateTaskEntry();
    }
}
