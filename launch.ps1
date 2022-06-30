docker run -d --rm -p 5192:80 jenkinstestapp | Out-Null
Start-Process http://localhost:5192