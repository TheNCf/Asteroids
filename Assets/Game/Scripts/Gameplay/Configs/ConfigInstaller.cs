using Game.Scripts.Core;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay.Configs
{
    public class ConfigInstaller : MonoInstaller<ConfigInstaller>
    {
        [SerializeField] private TextAsset _asteroidConfigJson;
        [SerializeField] private TextAsset _bulletConfigJson;
        [SerializeField] private TextAsset _laserConfigJson;
        [SerializeField] private TextAsset _playerCharacterConfigJson;
        [SerializeField] private TextAsset _ufoConfigJson;
        [SerializeField] private TextAsset _worldConfigJson;
        [SerializeField] private TextAsset _machineGunConfigJson;
        [SerializeField] private TextAsset _laserGunConfigJson;

        public override void InstallBindings()
        {
            LoadConfigs();
        }

        private void LoadConfigs()
        {
            AsteroidConfig asteroidConfig = JsonDeserializer.Parse<AsteroidConfig>(_asteroidConfigJson);
            BulletConfig bulletConfig = JsonDeserializer.Parse<BulletConfig>(_bulletConfigJson);
            LaserConfig laserConfig = JsonDeserializer.Parse<LaserConfig>(_laserConfigJson);
            PlayerCharacterConfig playerCharacterConfig =
                JsonDeserializer.Parse<PlayerCharacterConfig>(_playerCharacterConfigJson);
            UfoConfig ufoConfig = JsonDeserializer.Parse<UfoConfig>(_ufoConfigJson);
            WorldConfig worldConfig = JsonDeserializer.Parse<WorldConfig>(_worldConfigJson);
            MachineGunConfig machineGunConfig = JsonDeserializer.Parse<MachineGunConfig>(_machineGunConfigJson);
            LaserGunConfig laserGunConfig = JsonDeserializer.Parse<LaserGunConfig>(_laserGunConfigJson);
            
            Container.Bind<AsteroidConfig>()
                .FromInstance(asteroidConfig)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<BulletConfig>()
                .FromInstance(bulletConfig)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<LaserConfig>().
                FromInstance(laserConfig)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<PlayerCharacterConfig>()
                .FromInstance(playerCharacterConfig)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<UfoConfig>()
                .FromInstance(ufoConfig)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<WorldConfig>()
                .FromInstance(worldConfig)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<MachineGunConfig>()
                .FromInstance(machineGunConfig)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<LaserGunConfig>()
                .FromInstance(laserGunConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}