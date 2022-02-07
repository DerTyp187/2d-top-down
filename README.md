# 2D-Top-Down
### Unity Version: 2021.2.10f1

## Start with Git
[GitLab Documentation](https://docs.gitlab.com/ee/gitlab-basics/start-using-git.html)
### Set Git config
`git config --global user.name "your_username"`

`git config --global user.email "your_email_address@tealfire.de"`

`git config --global --list`

### Clone Project
Get in the folder you want your project to be in.

Open Console in this folder.

`git clone git@tealfire.de:gamedev/2d-top-down.git`

`cd 2d-top-down`

### Add Remote
`git remote add origin git@tealfire.de:gamedev/2d-top-down.git`

### Commit and Push
Add all files to commit and create Commit
`git commit -a -m "COMMENT TO DESCRIBE THE INTENTION OF THE COMMIT"`

`git push origin <branch>`

### Pull
`git pull origin <branch>`


### Branch
To use a different branch just add another branch name in `git push origin <branch>`

if the branch exists it pushes into it and if not it creates a new branch


### General
See what you changed:
`git status`
