using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class GameCategory
    {
        // 种类ID，主键
        public int Id { get; set; }

        // 种类名称，必填
        [Required]
        public string Name { get; set; }

        // 种类描述，可选
        public string Description { get; set; }

        // 种类下的游戏列表，导航属性
        public virtual ICollection<Game> Games { get; set; }

    }
}