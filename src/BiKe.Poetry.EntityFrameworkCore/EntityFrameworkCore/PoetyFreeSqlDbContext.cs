using BiKe.Poetry.Setting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiKe.Poetry.EntityFrameworkCore
{
    public static class PoetyFreeSqlDbContext
    {
        private static IFreeSql FsqlDb;

        public static IFreeSql GetFreeSql()
        {
            if (FsqlDb == null)
            {
                FsqlDb = new FreeSql.FreeSqlBuilder()
                    .UseConnectionString(FreeSql.DataType.PostgreSQL, ConfigurationSetting.ConnectionString)
                    .UseAutoSyncStructure(true) //自动迁移实体的结构到数据库
                    .Build(); //请务必定义成 Singleton 单例模式;   
            }
            return FsqlDb;
        }

    }
}
