﻿
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace QuickBootstrap.Helpers
{
    // 依赖注入构造器
    public sealed class UnityHelper
    {
        #region 单例

        private static readonly UnityHelper _instance = new UnityHelper();

        public static UnityHelper Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        private readonly IUnityContainer _unityContainer = new UnityContainer();

        private UnityHelper()
        {
            // 从配置节点中取得依赖注入的条目，并注入Unity 容器
            var configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
            if (configuration != null)
            {
                configuration.Configure(_unityContainer, "defaultContainer");
            }
        }

        public IUnityContainer Unity
        {
            get { return _unityContainer; }
        }
    }
}