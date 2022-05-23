#!/bin/sh

export POST_URL=https://adopseback.inherently.xyz/api/evaluation
export TEMPLATE_FILE=template-evaluation.json
export CONFIG_FILE=config-evaluation.yml
export ITER=1000
./gogenjson
