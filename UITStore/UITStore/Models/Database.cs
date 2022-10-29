using System;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using UITStore.Models;
using Xamarin.Forms;

namespace ProjSQLite
{
    public class Database
    {
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public bool TaoCSDL()
        {
            try
            {
                var connection = new SQLiteConnection
                    (Path.Combine(folder, "uitStore.db"));
                connection.CreateTable<User>();
                Console.WriteLine(connection.Table<User>().ToList());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool addUser(User user)
        {
            try
            {
                var connection = new SQLiteConnection(Path.Combine(folder, "uitStore.db"));
                connection.Insert(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // public bool ThemHoa(Hoa h)
        // {
        //   try
        //   {
        //     var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "uitStore.db"));
        //     connection.Insert(h);
        //     return true;
        //   }
        //   catch { return false; }
        // }
        public async Task<bool> updateUser(User user)
        {
            //fixme
            try
            {
                var connection = new SQLiteConnection(Path.Combine(folder, "uitStore.db"));
                var oldUser = getUser(user.username, user.password);
                oldUser.username = user.username;
                oldUser.password = user.password;
                oldUser.fullname = user.fullname;
                oldUser.telephone = user.telephone;
                oldUser.address = user.address;
                connection.Update(oldUser);
                Application.Current.Properties["user"] = user;
                await Application.Current.SavePropertiesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteUser(User user)
        {
            try
            {
                var connection = new SQLiteConnection(Path.Combine(folder, "uitStore.db"));
                connection.Delete(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User getUser(string username, string password)
        {
            try
            {
                var connection = new SQLiteConnection(Path.Combine(folder, "uitStore.db"));
                var users = connection.Table<User>().ToList();
                foreach (var result in users)
                    if (result.username == username && result.password == password)
                        return result;

                return null;
            }
            catch
            {
                return null;
            }
        }
        // public User getUser(User user)
        // {
        //   try
        //   {
        //     string cautruyvan = "select * from User where username=" + user.username + " and password="+user.password;
        //     var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "uitStore.db"));
        //     return connection.Query<User>(cautruyvan);
        //   }
        //   catch { return null; }
        // }
    }
}