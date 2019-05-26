using System;
using System.IO;
using Realms;

namespace blog.server.DataAccesses.Base
{
    public class RealmDatabase
    {
        public static readonly RealmConfiguration Config;

        static RealmDatabase()
        {
            var folder = Path.Combine(Environment.CurrentDirectory, "Database");
            var file = Path.Combine(folder, "realm.realm");
            Directory.CreateDirectory(folder);

            Config = new RealmConfiguration(file);
        }

        private static Realm Instance { get; set; } = null;

        protected static Realm Database => Instance == null
            ? Realm.GetInstance(Config)
            : Instance;
    }
}
