# Fortnite Tracker Refresh
Silent application to have fortnite tracker check for new stats. This saves RAM/CPU/etc. when compared to leaving fortnite tracker open in the background due to the fact it isn't "running" the webpage, merely making the web requests needed to have your stats updated.

### Usage/Install

1. Download the exe from the releases section.
2. Create a file called `fortnite_info.txt` in your My Documents folder.
3. Open `fortnite_info.txt` in any text editor, put your platform on the first line (for most just "pc" (no quotes)) and your username (your epic games account username) on the second line. For example:
```
pc
jam1garner
```
4. If you want it to always open silently on startup (Note: it has a near nonexistant CPU footprint and a very small memory footprint and will only be active while you are in game) go into command prompt in the same folder as `FNTrackerRefresh.exe` and run the following command:
```
FNTrackerRefresh.exe install
```
5. (Do this even if you did step 4) Now just run `FNTrackerRefresh.exe`. It will work silently in the background to keep fortnitetracker updated for you. (If you did do step 4 you no longer need to run it, if you didn't do step 4 you will need to rerun the exe after every restart when you want to use it)


### How to Uninstall

1. Windows Key + R
2. Type in `shell:startup` and hit enter
3. Find `FNTrackerRefresh.exe` in the folder that just opened and delete it
