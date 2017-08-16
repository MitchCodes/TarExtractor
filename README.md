# TarExtractor
C# Windows Forms program created to make extracting Tar files easy in a GUI with Docker.

## What this program is
This program was created to mess with some stuff with Docker and to build a useful tool. One of the neat things Docker can do for you is basically run Linux commands in the command line using a Linux Docker container.

One of the nice features of Linux is the tar command to extract a tar file. On Windows, this is not always so easy. This program basically wraps the Docker commands to extract a Tar file inside of a Windows Form GUI.

## How to run
You must be able to pull down the code and compile it. Currently, I do not have precompiled binaries included in this Github.

## Usage notes
This program will download the image for ubuntu inside of your Linux container if you do not already have it. The program spins up Linux containers that are removed after they are used to extract the Tar files.

## Program prerequisites 
1) Hyper-V enabled on your machine
2) Docker for Windows running with Linux containers enabled
3) Share the drive the Tar file you are trying to extract is in within Docker settings

## Technologies used in making this application
1) C#
2) Windows Forms
3) Docker CLI commands