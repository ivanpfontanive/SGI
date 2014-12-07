using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SGI.DAL;
using SGI.Dominio;
using SGI.Dominio.Entidades;
using SGI.Dominio.Interfaces.Repositorios;
using SGI.Infra.EF;
using System;

namespace SGI.Ioc
{
    public class WindsorFactory : IDisposable
    {
        /// <summary>
        /// Controle da conclusão da inicialização do Singleton.
        /// </summary>
        private bool startupComplete = false;

        /// <summary>
        /// Controle da conclusão da inicialização do Singleton.
        /// </summary>
        private readonly object locker = new object();

        private WindsorContainer Container { get; set; }

        /// <summary>
        /// Obtem uma única instância para classe WindsorFactory.
        /// </summary>
        /// <returns>Retorna a instância.</returns>
        private static WindsorFactory Instancia
        {
            get { return Nested.instancia; }
        }

        private WindsorFactory()
        { }

        /// <summary>
        /// Inicializa a fabrica do container de injeção de dependências.
        /// </summary>
        public static void Iniciar()
        {
            WindsorFactory.Instancia.IniciarContainer();
        }

        private void IniciarContainer()
        {
            // Garante que duas chamadas para a instância desta classe antes da inicialização não possam ocorrer.
            if (!this.startupComplete)
            {
                lock (this.locker)
                {
                    if (!this.startupComplete)
                    {
                        // Cria uma instância do Cantainer.
                        this.Container = new WindsorContainer();

                        this.startupComplete = true;

                        this.Container.Register(Component.For<IBaseDAL<BaseDominio>>()
                                                         .ImplementedBy<BaseDAL<BaseDominio>>()
                                                         .LifeStyle.Transient);

                        this.Container.Register(Component.For<IUsuarioDAL>()
                                                         .ImplementedBy<UsuarioDAL>()
                                                         .LifeStyle.Transient);

                        this.Container.Register(Component.For<IIdeiaDAL>()
                                                         .ImplementedBy<IdeiaDAL>()
                                                         .LifeStyle.Transient);

                        this.Container.Register(Component.For<IRepositorioContexto>()
                                                         .ImplementedBy<IdeiaEFContext>()
                                                         .LifeStyle.PerWebRequest);
                    }
                }
            }
        }

        /// <summary>
        /// Resolve uma dependência necessária para a aplicação.
        /// </summary>
        /// <typeparam name="T">Intercave que terá sua dependência resolvida.</typeparam>
        /// <returns>Instância da interface requisitada.</returns>
        public static T Resolver<T>() where T : class
        {
            return WindsorFactory.Instancia.Container.Resolve<T>();
        }

        /// <summary>
        /// Resolve uma dependência necessária para a aplicação.
        /// </summary>
        /// <typeparam name="T">Intercave que terá sua dependência resolvida.</typeparam>
        /// <param name="nome">Quando há mais de uma classe concreta que implementa a mesma interface, deve-se resolve-lá pelo nome registrado no container.</param>
        /// <returns>Instância da interface requisitada.</returns>
        public static T Resolver<T>(string nome) where T : class
        {
            return WindsorFactory.Instancia.Container.Resolve<T>(nome);
        }

        /// <summary>
        /// Efetua a finalização do contâiner.
        /// </summary>
        public static void Finalizar()
        {
            WindsorFactory.Instancia.Dispose();
        }

        private class Nested
        {
            internal readonly static WindsorFactory instancia = new WindsorFactory();

            static Nested()
            {
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Destrutor.
        /// </summary>
        ~WindsorFactory()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Finaliza o objeto.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finaliza o objeto.
        /// </summary>
        /// <param name="disposing">Parâmetro de controle do Método Dispose.</param>
        private void Dispose(bool disposing)
        {
            #region Implementação

            //Encerramento dos objetos da instância
            if (this.Container != null)
            {
                this.Container.Dispose();
                this.Container = null;
            }

            #endregion Implementação
        }

        #endregion IDisposable Members
    }
}