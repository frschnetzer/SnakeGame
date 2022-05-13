using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class SnakeGameDb
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Highscore { get; set; }
    }
}