namespace MiniSO.Entidades
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MiniStackOModel : DbContext
    {
        public MiniStackOModel()
            : base("name=MiniStackOModel")
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Medal> Medal { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<QuestionTag> QuestionTag { get; set; }
        public virtual DbSet<UserMedal> UserMedal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Answer>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Medal>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Medal>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Medal>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Medal>()
                .HasMany(e => e.UserMedal)
                .WithRequired(e => e.Medal)
                .HasForeignKey(e => e.Medal_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answer)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.Question_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.QuestionTag)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.Question_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.QuestionTag)
                .WithRequired(e => e.Tag)
                .HasForeignKey(e => e.Tag_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Answer)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Question)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserMedal)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionTag>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<UserMedal>()
                .Property(e => e.Status)
                .IsUnicode(false);
        }
    }
}
