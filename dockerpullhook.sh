#!bin/bash
curl --request POST \
  --url 'http://datacat.nerdcats.io:8080/pull?token=nerdcats' \
  --header 'content-type: application/json' \
  --data '{\n	"mode": "docker",\n	"image": "nerdcats/datacat:prod",\n	"arguments": "--name datacat -p 5000:5000"\n}'