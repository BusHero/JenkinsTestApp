#!/bin/sh

if docker ps --format "{{.Names}}" | grep -q "$1"
then
	docker stop "$1"
fi