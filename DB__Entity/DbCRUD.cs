using DB__Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace DB__Entity
{
    public class DbCRUD
    {     
        /// <summary>
        /// Добавление пользователя в БД
        /// </summary>
        /// <param name="userName"></param>
        public static async Task AddUserToDb(string userName)
        {
            await using (var ctx = new Context())
            {
                using (var txn = ctx.Database.BeginTransaction())
                {
                    var user = new User() { Name = userName };
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                    txn.Commit();
                }
            }
        }

        /// <summary>
        /// Получение iD по имени пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static async Task<int> GetUserId(string userName)
        {
            Console.WriteLine(userName);
            await using (var ctx = new Context())
            {
                var id = ctx.Users.Where(n => n.Name == userName).Select(i => i.ID_user).FirstOrDefault();
                ctx.SaveChanges();
                Console.WriteLine(id);
                return id;
            }
        }

        public static async Task<List<string>> GetUreadMessages(int toUserId)
        {
            await using (var ctx = new Context())
            {
                var msg = ctx.Messages.Where(b => b.isReceived == false).Where(i => i.ToUserId == toUserId).Select(t => t.text).ToList();
                return msg;
            }
        }

        /// <summary>
        /// Возвращает true, если есть пользователь с указанным имемем в параметре, иначе false
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static async Task<bool> IsExistUser(string userName)
        {
            await using (var ctx = new Context())
            {
                var isExist = ctx.Users.Where(n => n.Name == userName);
                ctx.SaveChanges();
                if(string.IsNullOrEmpty(isExist.ToString())) return true;
                else return false;                
            }
        }


        /// <summary>
        /// Добавление в таблицу сообщений переданного сообщения
        /// </summary>
        /// <param name="fromUserName"></param>
        /// <param name="toUserName"></param>
        /// <param name="textMessage"></param>
        /// <param name="isResived"></param>
        /// <returns></returns>
        public static async Task AddMessageToDb(int idFromUser, int idToUser, string textMessage, bool isResived)
        {
            await using (var ctx = new Context())
            {
                using (var txn = ctx.Database.BeginTransaction())
                {
                    var message = new Message()
                    {
                        FromUserId = idFromUser,
                        ToUserId = idToUser,
                        text = textMessage,
                        isReceived = isResived
                    };
                    ctx.Messages.Add(message);
                    ctx.SaveChanges();
                    txn.Commit();
                }
            }
        }
    }
}
