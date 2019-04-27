# Darkorbit
Continued project of NettyBaseReloaded


## In this project the main goal is to integrate the DotNetty library instead of outdated XSocket lib and make the game work smoother without any crashes.
### Mistakes in base of previous project:
* Commands have no interface
* Handler works with a Dictionary searching packets
* Commands go through a clean handler without any checks if session is still active or disposed - causing errors.
[e.g Packet.Builder.LegacyModule(gameSession, message) => { gameSession.Client.Send(..) } when gameSession is exposed > causing error to be dropped]
* Sockets can't be smoothly stopped, no safe shutdowns.
