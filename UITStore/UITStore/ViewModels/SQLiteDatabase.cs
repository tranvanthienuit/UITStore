using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using UITStore.Models;
using Xamarin.Forms;

namespace UITStore
{
    public class SQLiteDatabase
    {
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public bool CreateDatabase()
        {
            try
            {
                var connection = new SQLiteConnection
                    (Path.Combine(folder, "uitStore.db"));
                connection.CreateTable<User>();
                connection.CreateTable<Cart>();
                connection.CreateTable<Favourite>();
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

        public async Task<bool> updateUser(User user)
        {
            
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
       
        public bool addCart(Cart cart)
        {
            try
            {
                var connection = new SQLiteConnection(Path.Combine(folder, "uitStore.db"));
                connection.Insert(cart);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ObservableCollection<Cart> getCart(int userid)
        {
            try
            {
                var connection = new SQLiteConnection(Path.Combine(folder, "uitStore.db"));
                var cart = connection.Table<Cart>().ToList();
                ObservableCollection<Cart> carts = new ObservableCollection<Cart>();
                foreach (var result in cart)
                    if (result.userid == userid)
                    {
                        carts.Add(result);
                    }
                        
                return carts;
            }
            catch
            {
                return null;
            }
        }
        public Cart updateCart(int id, int quantity)
        {
            try
            {
                var connection = new SQLiteConnection(Path.Combine(folder, "uitStore.db"));
                var cart = connection.Table<Cart>().ToList();
                foreach (var item in cart)
                {
                    if (item.id == id)
                    {
                        item.quantity = quantity;
                        connection.Update(item);
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public Cart deleteCart(int id)
        {
            try
            {
                var connection = new SQLiteConnection(Path.Combine(folder, "uitStore.db"));
                var cart = connection.Table<Cart>().ToList();
                foreach (var item in cart)
                {
                    if (item.id == id)
                    {
                        connection.Delete(item);
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool addFavourite(Favourite favourite)
        {
            try
            {
                var connection = new SQLiteConnection(Path.Combine(folder, "uitStore.db"));
                connection.Insert(favourite);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ObservableCollection<Favourite> getFavourite(int userid)
        {
            try
            {
                var connection = new SQLiteConnection(Path.Combine(folder, "uitStore.db"));
                var favourite = connection.Table<Favourite>().ToList();
                ObservableCollection<Favourite> favourites = new ObservableCollection<Favourite>();
                foreach (var item in favourite)
                {
                    if (item.userid == userid)
                    {
                        favourites.Add(item);
                    }
                }
                return favourites;
            }
            catch
            {
                return null;
            }
        }
        public bool ExistFavourite(Favourite favourite)
        {
            try
            {
                var connection = new SQLiteConnection(Path.Combine(folder, "uitStore.db"));
                var favourites = connection.Table<Favourite>().ToList();
                var result = favourites.Where(item => item.userid == favourite.userid && item.sneakerId == favourite.sneakerId);
                if(result.Any())
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public Favourite deleteFavourite(int id)
        {
            try
            {
                var connection = new SQLiteConnection(Path.Combine(folder, "uitStore.db"));
                var favourites = connection.Table<Favourite>().ToList();
                foreach (var item in favourites)
                {
                    if (item.id == id)
                    {
                        connection.Delete(item);
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}