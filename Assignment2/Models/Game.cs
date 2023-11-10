using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class Game
    {
        // 游戏ID，主键
        public int Id { get; set; }

        // 游戏名称，必填
        [Required]
        public string Name { get; set; }

        // 游戏种类ID，外键
        [ForeignKey("GameCategory")]
        public int CategoryId { get; set; }

        // 游戏种类，导航属性
        public virtual GameCategory GameCategory { get; set; }

        public double price { get; set; }
        // 游戏图片URL，可选
        public string ImageUrl { get; set; }

        // 游戏评分，可选
        public string Evaluation { get; set; }

        public string VideoUrl { get; set; }
    }
}