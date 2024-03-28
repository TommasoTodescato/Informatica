cmake_minimum_required(VERSION 3.28)
project(gioco_impiccato)

set(CMAKE_CXX_STANDARD 17)

add_executable(gioco_impiccato main.cpp
        player.cpp
        include/player.h
        file_handler.cpp
        include/file_handler.h
)
