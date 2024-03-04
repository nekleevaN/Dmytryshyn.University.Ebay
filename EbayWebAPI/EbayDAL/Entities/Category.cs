using EbayDAL.Enums;

namespace EbayDAL.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryType Type { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category() : base() { }
        public Category(int id, string name, int parentCategoryId, string descriprion, CategoryType categoryType) : base(id)
        {
            Name = name;
            ParentCategoryId = parentCategoryId;
            Description = descriprion;
            Type = categoryType;
        }
    }
}
