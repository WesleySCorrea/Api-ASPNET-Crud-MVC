using System.ComponentModel;

namespace ApiCrudTasks.Enums
{
    public enum StatusTask
    {
        [Description("To do")]
        TODO = 1,

        [Description("In progress")]
        INPROGRESS = 2
            ,
        [Description("Completed")]
        COMPLETED = 3,
    }
}
